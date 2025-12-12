namespace BDD.Playwright.Core.Helpers
{
    using System;
    using System.IO;
    using System.Net;
    using BDD.Playwright.Core.Configuration;
    using BDD.Playwright.Core.Enums;
    using BDD.Playwright.Core.Loggers;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    using RestSharp;
    using SkiaSharp;

    /// <summary>
    /// Forms API Helper.
    /// </summary>
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class FormsAPIHelper
    {
        private static readonly string[] Separator = [","];

        private readonly bool authenticationRequired;
        private readonly string userName;
        private readonly string passWord;
        private readonly RestAPIHelper restAPIHelper;
        private readonly ApplicationLogger logger;
        private readonly string baseUrl;

        private string batchFolderName;
        private string authToken;
        private DateTime tokenExpiryTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormsAPIHelper"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        public FormsAPIHelper(ApplicationLogger logger)
        {
            this.logger = logger;
            baseUrl = GlobalConfig.Settings.PDFCompareUrls.PythonBaseUrl;
            restAPIHelper = new RestAPIHelper(baseUrl);
            authenticationRequired = bool.Parse(GlobalConfig.Settings.Authentication);
            userName = GlobalConfig.Settings.Username;
            passWord = GlobalConfig.Settings.Password;
        }

        /// <summary>
        /// Saves a file by sending a POST request to the endpoint.
        /// </summary>
        /// <param name="filePath">The local file path of the file to be uploaded.</param>
        /// <returns>The file path from the server's response if the upload is successful.</returns>
        public string SaveFile(string filePath)
        {
            if (authenticationRequired && !Authentication())
            {
                logger.WriteLine("Authentication failed");
                return null;
            }

            var uploadrequest = new RestRequest("savefile/");
            if (authenticationRequired)
            {
                uploadrequest.AddHeader("Authorization", $"Token {authToken}");
            }

            uploadrequest.AddFile("file", filePath);
            var response = restAPIHelper.PostRequest(uploadrequest);
            if (response.IsSuccessful)
            {
                var jsonResponse = JObject.Parse(response.Content);
                var filePathFromResponse = jsonResponse["filePath"].ToString();
                logger.WriteLine(filePathFromResponse.ToString());
                return filePathFromResponse;
            }
            else
            {
                logger.WriteLine("Error uploading file. Status code: " + response.StatusCode);
                logger.WriteLine("Error message: " + response.ErrorMessage);
                return null;
            }
        }

        /// <summary>
        /// Validates Text Style.
        /// </summary>
        /// <param name="baseFilePathFromResponse">base file path.</param>
        /// <param name="actualFilePathFromResponse">actual file path.</param>
        /// <returns>RestResponse.</returns>
        public RestResponse TextStyleValidation(string baseFilePathFromResponse, string actualFilePathFromResponse)
            => ComparePDFFiles("textstyle_validation/", baseFilePathFromResponse, actualFilePathFromResponse, FormValidationType.TS);

        /// <summary>
        /// Pixel Validation.
        /// </summary>
        /// <param name="baseFilePathFromResponse">base file path.</param>
        /// <param name="actualFilePathFromResponse">actual file path.</param>
        /// <returns>RestResponse.</returns>
        public RestResponse PixelValidation(string baseFilePathFromResponse, string actualFilePathFromResponse)
            => ComparePDFFiles("pixel_validation/", baseFilePathFromResponse, actualFilePathFromResponse, FormValidationType.P2P);

        public RestResponse ContentValidation(string baseFilePathFromResponse, string actualFilePathFromResponse)
            => ComparePDFFiles("content_validation/", baseFilePathFromResponse, actualFilePathFromResponse, FormValidationType.CT);

        /// <summary>
        /// All Validation.
        /// </summary>
        /// <param name="baseFilePathFromResponse">base file path.</param>
        /// <param name="actualFilePathFromResponse">actual file path.</param>
        /// <returns>RestResponse.</returns>
        public RestResponse AllthePdfValidation(string baseFilePathFromResponse, string actualFilePathFromResponse)
            => ComparePDFFiles("file_validation/", baseFilePathFromResponse, actualFilePathFromResponse, FormValidationType.ALL);

        public RestResponse CustomIgnoreDynamicValidation(string baseFilePathFromResponse, string actualFilePathFromResponse, bool standardform)
            => ComparePDF_IgnoreDynamic("content_validation_ignore_dynamic/", baseFilePathFromResponse, actualFilePathFromResponse, FormValidationType.IDC, standardform);

        public RestResponse StandardIgnoreDynamicValidation(string baseFilePathFromResponse, string actualFilePathFromResponse, bool standardform, string prefix, string suffix)
            => ComparePDF_IgnoreDynamic("content_validation_ignore_dynamic/", baseFilePathFromResponse, actualFilePathFromResponse, FormValidationType.IDC, standardform, prefix, suffix);

        public RestResponse CustomValidateDynamicValidation(string baseFilePathFromResponse, string actualFilePathFromResponse, string excelfile, bool standardform)
            => ComparePDF_ValidateDynamic("dynamic_content_validation/", baseFilePathFromResponse, actualFilePathFromResponse, excelfile, standardform);

        public RestResponse StandardValidateDynamicValidation(string baseFilePathFromResponse, string actualFilePathFromResponse, string excelfile, bool standardform, string prefix, string suffix)
            => ComparePDF_ValidateDynamic("dynamic_content_validation/", baseFilePathFromResponse, actualFilePathFromResponse, excelfile, standardform, prefix, suffix);

        /// <summary>
        /// Uploads batch files for comparison by saving the base and actual files to specific locations.
        /// </summary>
        /// <param name="baseFilesPath">The filepath to the base files that need to be uploaded.</param>
        /// <param name="actualFilesPath">The filepath to the actual files that need to be uploaded.</param>
        /// <param name="userName">The username associated with the batch operation.</param>
        /// <returns>The name of the folder where the batch files saved.</returns>
        public string UploadBatchFiles(string baseFilesPath, string actualFilesPath, string userName)
        {
            batchFolderName = BatchSaveFiles(baseFilesPath, "Base", userName);
            BatchSaveFiles(actualFilesPath, "Actual", userName);
            return batchFolderName;
        }

        /// <summary>
        ///  Executes a batch file comparison operation by sending a POST request to the API endpoint.
        /// </summary>
        /// <param name="batchName">The name of the batch to be compared.</param>
        /// <param name="userName">The username associated with the batch operation.</param>
        /// <returns>The response from API.</returns>
        public RestResponse RunBatchFilesCompare(string batchName, string userName)
        {
            if (authenticationRequired && !Authentication())
            {
                logger.WriteLine("Authentication failed");
                return null;
            }

            var request = new RestRequest("runbatch/");
            if (authenticationRequired)
            {
                request.AddHeader("Authorization", $"Token {authToken}");
            }

            request.AddParameter("userName", userName);
            request.AddParameter("batchName", batchName);
            request.AddParameter("batchType", "sv");
            var response = restAPIHelper.PostRequest(request);
            if (!response.IsSuccessful)
            {
                logger.WriteLine($"Failed to run batch files: {response.ErrorMessage}");
            }
            else
            {
                logger.WriteLine("Batch files compared successfully.");
            }

            return response;
        }

        /// <summary>
        /// Validates the API response to ensure the PDF file comparison was successful.
        /// </summary>
        /// <param name="response">Contains the response.</param>
        public void ValidateResponse(RestResponse response)
        {
            logger.WriteLine(response.Content.ToString());
            var jsonObject = JObject.Parse(response.Content);

            _ = response.Content.ToString();
            var completematch = (bool)jsonObject["completematch"];
            if (completematch)
            {
                logger.WriteLine("PDF File Comparision Success");
            }
            else
            {
                logger.WriteLine("PDF File Comparision Failed");
            }

            Assert.IsTrue(completematch, "Complete Match is NOT found");
        }

        /// <summary>
        /// Validates the content of the API response to check if it matches the expected success message.
        /// </summary>
        /// <param name="response">Contains the API response.</param>
        public void ValidateContent(RestResponse response)
        {
            var validation = JsonConvert.DeserializeObject<string>(response.Content);
            if (!string.IsNullOrEmpty(validation) && validation == "Dynamic validation is Completed")
            {
                logger.WriteLine("Validation Passed: Dynamic validation is Completed");
            }
            else
            {
                logger.WriteLine("Validation Failed: Expected message not found");
            }
        }

        /// <summary>
        /// Loads an image from the specified file path and returns it as an SKBitmap object.
        /// </summary>
        /// <param name="path">The file path of the image to be loaded. </param>
        /// <returns>SKBitmap representing the loaded image. </returns>
        private static SKBitmap LoadBitmap(string path)
        {
            using var stream = File.OpenRead(path);
            return SKBitmap.Decode(stream);
        }

        /// <summary>
        /// Saves an SKBitmap object as a PNG image to the specified file path.
        /// </summary>
        /// <param name="bitmap">The SKBitmap object representing the image to be saved.</param>
        /// <param name="path">The file path where the PNG image is saved.</param>
        private static void SaveBitmapAsPng(SKBitmap bitmap, string path)
        {
            using var image = SKImage.FromBitmap(bitmap);
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            using var stream = File.OpenWrite(path);
            data.SaveTo(stream);
        }

        /// <summary>
        /// Combines two SKBitmap images side by side into a single SKBitmap object.
        /// </summary>
        /// <param name="image1">The first SKBitmap image to be combined.</param>
        /// <param name="image2">The second SKBitmap image to be combined.</param>
        /// <returns>A new SKBitmap object containing the combined images side by side.</returns>
        private static SKBitmap CombineImagesSideBySide(SKBitmap image1, SKBitmap image2)
        {
            var width = image1.Width + image2.Width;
            var height = Math.Max(image1.Height, image2.Height);

            var combinedImage = new SKBitmap(width, height);
            using (var canvas = new SKCanvas(combinedImage))
            {
                canvas.DrawBitmap(image1, 0, 0);
                canvas.DrawBitmap(image2, image1.Width, 0);
            }

            return combinedImage;
        }

        /// <summary>
        ///  Validates the content of the API response to check if it status is 200.
        /// </summary>
        /// <param name="response">Response.</param>
        public void ValidateStatusCode(RestResponse response)
        {
            logger.WriteLine(response.StatusCode.ToString());
            if (response.StatusCode == HttpStatusCode.OK)
            {
                logger.WriteLine("Status Code is Ok");
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Status Code should be OK");
            }
            else
            {
                logger.WriteLine("Error Occurred in the Status Code");
                Assert.Fail($"Unexpected status code: {response.StatusCode}");
            }
        }

        /// <summary>
        /// Compares two PDF files by sending a POST request to the API endpoint..
        /// </summary>
        /// <param name="endpoint">The API endpoint to which the comparison request is sent.</param>
        /// <param name="baseFilePath">The filepath of the base Pdf file to compare. </param>
        /// <param name="actualFilePath">The filepath of the actual Pdf file to be compared against the base Pdf file.</param>
        /// <param name="formValidationType">The type of Formvalidationtype to be performed on the pdf files.</param>
        /// <returns>Gets the response from the API including the status code and content.</returns>
        private RestResponse ComparePDFFiles(string endpoint, string baseFilePath, string actualFilePath, FormValidationType formValidationType)
        {
            if (authenticationRequired && !Authentication())
            {
                logger.WriteLine("Authentication failed.");
                return null;
            }

            var basefilepath = baseFilePath.Replace("\\", "\\\\");
            var actualfilepath = actualFilePath.Replace("\\", "\\\\");
            var requestBody = JsonConvert.SerializeObject(new
            {
                base_file_path = basefilepath,
                actual_file_path = actualfilepath,
            });

            // var uploadPDFFilerequest = new RestRequest(endpoint);
            var uploadPDFFilerequest = new RestRequest(endpoint)
            {
                Timeout = TimeSpan.FromMinutes(500),
            };
            if (authenticationRequired)
            {
                uploadPDFFilerequest.AddHeader("Authorization", $"Token {authToken}");
            }

            uploadPDFFilerequest.AddBody(requestBody);
            var response = restAPIHelper.PostRequest(uploadPDFFilerequest);
            logger.WriteLine(response.StatusCode.ToString());
            logger.WriteLine(response.Content);
            GetImage(basefilepath, actualfilepath, response, formValidationType);
            return response;
        }

        /// <summary>
        /// Compares two PDF files by sending a POST request to the API endpoint.
        /// </summary>
        /// <param name="endpoint">The API endpoint to which the comparison request is sent.</param>
        /// <param name="baseFilePath">The filepath of the base Pdf file to compare.</param>
        /// <param name="actualFilePath">The filepath of the actual Pdf file to be compared against the base Pdf file.</param>
        /// <param name="formValidationType">The type of Formvalidationtype to be performed on the pdf files.</param>
        /// <param name="standardform">Indicates the use of standard form validation and default is false.</param>
        /// <param name="prefix1">Prefix is optional and to be considered during comparison.Used only if <paramref name="standardform"/> is <c>true</c>.</param>
        /// <param name="suffix1">Suffix is optional and to be considered during comparison.Used only if <paramref name="standardform"/> is <c>true</c>.</param>
        /// <returns>Gets the response from the API including the status code and content.</returns>
        private RestResponse ComparePDF_IgnoreDynamic(string endpoint, string baseFilePath, string actualFilePath, FormValidationType formValidationType, bool standardform = default, string prefix1 = default, string suffix1 = default)
        {
            if (authenticationRequired && !Authentication())
            {
                logger.WriteLine("Authentication failed.");
                return null;
            }

            var basefilepath = baseFilePath.Replace("\\", "\\\\");
            var actualfilepath = actualFilePath.Replace("\\", "\\\\");
            var requestBody = standardform
                ? JsonConvert.SerializeObject(new
                {
                    base_file_path = basefilepath,
                    actual_file_path = actualfilepath,
                    standard_form = standardform,
                    prefix = prefix1,
                    suffix = suffix1,
                })
                : JsonConvert.SerializeObject(new
                {
                    base_file_path = basefilepath,
                    actual_file_path = actualfilepath,
                    standard_form = standardform,
                });

            var uploadPDFFilerequest = new RestRequest(endpoint);
            if (authenticationRequired)
            {
                uploadPDFFilerequest.AddHeader("Authorization", $"Token {authToken}");
            }

            uploadPDFFilerequest.AddBody(requestBody);
            var response = restAPIHelper.PostRequest(uploadPDFFilerequest);
            logger.WriteLine(response.StatusCode.ToString());
            logger.WriteLine(response.Content);
            GetImage(basefilepath, actualfilepath, response, formValidationType);
            return response;
        }

        /// <summary>
        /// Processes and uploads a batch of files to a specified endpoint.
        /// It iterates over a list of file paths by sending each file to the server along with parameters such as file type, user name, and batch type.
        /// If the file type is "Base" and it's the first file in the list, it captures the batch folder name from the server's response.
        /// </summary>
        /// <param name="batchFilesPath">A comma-separated string containing paths to the files to be uploaded.</param>
        /// <param name="fileType">Indicates the type of the files being uploaded. </param>
        /// <param name="userName">The user name associated with the file upload.</param>
        /// <returns>The batch folder name returned from the server.</returns>
        private string BatchSaveFiles(string batchFilesPath, string fileType, string userName)
        {
            if (authenticationRequired && !Authentication())
            {
                logger.WriteLine("Authentication failed");
                return null;
            }

            var batchFiles = batchFilesPath.Split(Separator, StringSplitOptions.RemoveEmptyEntries);
            var batchFileLength = batchFiles.Length;

            for (var i = 0; i < batchFileLength; i++)
            {
                var filePath = batchFiles[i].Trim();
                if (File.Exists(filePath))
                {
                    var request = new RestRequest("batchsavefile/");
                    if (authenticationRequired)
                    {
                        request.AddHeader("Authorization", $"Token {authToken}");
                    }

                    request.AddFile("file", filePath);
                    request.AddParameter("fileType", fileType);
                    request.AddParameter("userName", userName);
                    request.AddParameter("batchType", "sv");
                    if (!string.IsNullOrEmpty(batchFolderName))
                    {
                        request.AddParameter("batchName", batchFolderName);
                        logger.WriteLine($"{i} {batchFolderName}");
                    }

                    var response = restAPIHelper.PostRequest(request);
                    if (i == 0 && fileType.Contains("Base"))
                    {
                        batchFolderName = JsonConvert.DeserializeObject<dynamic>(response.Content)["BatchFolderPath"];
                    }
                }
                else
                {
                    logger.WriteLine($"File not found: {batchFiles[i]}");
                }
            }

            return batchFolderName;
        }

        /// <summary>
        /// Compares two PDF files by sending a POST request to the API endpoint.
        /// </summary>
        /// <param name="endpoint">The API endpoint to which the comparison request is sent.</param>
        /// <param name="baseFilePath">The filepath of the base Pdf file to compare.</param>
        /// <param name="actualFilePath">The filepath of the actual Pdf file to be compared against the base Pdf file.</param>
        /// <param name="formValidationType">The type of Formvalidationtype to be performed on the pdf files.</param>
        /// <param name="standardform">Indicates the use of standard form validation and default is false.</param>
        /// <param name="prefix1">Prefix is optional and to be considered during comparison.Used only if <paramref name="standardform"/> is <c>true</c>.</param>
        /// <param name="suffix1">Suffix is optional and to be considered during comparison.Used only if <paramref name="standardform"/> is <c>true</c>.</param>
        /// <returns>Gets the response from the API including the status code and content.</returns>
        private RestResponse ComparePDF_ValidateDynamic(string endpoint, string baseFilePath, string actualFilePath, string excelfile, bool standardform = default, string prefix1 = default, string suffix1 = default)
        {
            if (authenticationRequired && !Authentication())
            {
                logger.WriteLine("Authentication failed");
                return null;
            }

            var excelfileData = excelfile.Replace("\\", "\\\\");
            var basefilepath = baseFilePath.Replace("\\", "\\\\");
            var actualfilepath = actualFilePath.Replace("\\", "\\\\");
            var requestBody = standardform
                ? JsonConvert.SerializeObject(new
                {
                    base_file_path = basefilepath,
                    actual_file_path = actualfilepath,
                    data_file_path = excelfileData,
                    standard_form = standardform,
                    prefix = prefix1,
                    suffix = suffix1,
                })
                : JsonConvert.SerializeObject(new
                {
                    base_file_path = basefilepath,
                    actual_file_path = actualfilepath,
                    data_file_path = excelfileData,
                    standard_form = standardform,
                });
            var uploadPDFFilerequest = new RestRequest(endpoint);
            if (authenticationRequired)
            {
                uploadPDFFilerequest.AddHeader("Authorization", $"Token {authToken}");
            }

            uploadPDFFilerequest.AddBody(requestBody);
            var response = restAPIHelper.PostRequest(uploadPDFFilerequest);
            logger.WriteLine(response.StatusCode.ToString());
            logger.WriteLine(response.Content);
            return response;
        }

        /// <summary>
        /// Processes and saves images of the PDF comparison results based on the provided file paths and response data.
        /// </summary>
        /// <param name="basefilepath">The filepath of the base Pdf file to compare.</param>
        /// <param name="actualfilepath">The filepath of the actual Pdf file to be compared against the base Pdf file.</param>
        /// <param name="Response">The response from the endpoint containing the comparison results, including the number of pages in each PDF.</param>
        /// <param name="diffType">The type of form validation difference to check when processing the images.</param>
        private void GetImage(string basefilepath, string actualfilepath, RestResponse response, FormValidationType diffType)
        {
            var basefileName = Path.GetFileNameWithoutExtension(basefilepath);
            var actualfileName = Path.GetFileNameWithoutExtension(actualfilepath);
            var basepages = 0;
            var actualpages = 0;

            if (response.IsSuccessful)
            {
                var jsonResponse = JObject.Parse(response.Content);
                basepages = jsonResponse.Value<int?>("basepages") ?? 0;
                actualpages = jsonResponse.Value<int?>("actualpages") ?? 0;
            }

            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var imagePath = "FormsValidation//Images";
            var folderPath = Path.Combine(imagePath, timestamp);
            Directory.CreateDirectory(folderPath);
            if (basefileName.Contains("Base", StringComparison.OrdinalIgnoreCase))
            {
                ImageCheck(basefileName, diffType, "Base", basepages, folderPath);
            }

            if (actualfileName.Contains("Actual", StringComparison.OrdinalIgnoreCase))
            {
                ImageCheck(actualfileName, diffType, "Actual", actualpages, folderPath);
            }
        }

        /// <summary>
        /// Requests and retrieves images of specific pages from the PDF file, then saves the images if the request is successful.
        /// </summary>
        /// <param name="filename">The name of the PDF file without extension.</param>
        /// <param name="diffType">The type of form validation difference to be checked for each page of the PDF file.</param>
        /// <param name="fileType">The filetype indicates whether it is base or actual file being processed.</param>
        /// <param name="pages">The total number of pages in the PDF file.</param>
        /// <param name="folderPath">The folder path where the retrieved images will be saved.</param>
        private void ImageCheck(string filename, FormValidationType diffType, string fileType, int pages, string folderPath)
        {
            if (authenticationRequired && !Authentication())
            {
                logger.WriteLine("Authentication failed");
                throw new Exception("Authentication failed");
            }

            for (var i = 1; i <= pages; i++)
            {
                var uploadRequest = new RestRequest("getimage/");
                if (authenticationRequired)
                {
                    uploadRequest.AddHeader("Authorization", $"Token {authToken}");
                }

                uploadRequest.AddParameter("fileName", filename);
                uploadRequest.AddParameter("type", fileType);
                uploadRequest.AddParameter("page", i);
                uploadRequest.AddParameter("diffType", diffType.ToString().ToLower());

                var imageResponse = restAPIHelper.PostRequest(uploadRequest);
                if (imageResponse.IsSuccessful)
                {
                    AddScreenshots(imageResponse, fileType, i, diffType, folderPath);
                }
                else
                {
                    logger.WriteLine($"Error processing {fileType} page {i}: " + imageResponse.ErrorMessage);
                }
            }
        }

        /// <summary>
        /// Saves the image from the API response to a specified folder and creates a combined image of the base and actual pages for comparison.
        /// </summary>
        /// <param name="imageResponse">The response from the API containing the image bytes to be saved.</param>
        /// <param name="fileType">The filetype indicates whether it is base or actual file being processed.</param>
        /// <param name="page">The page number of the PDF file for which the image is being processed.</param>
        /// <param name="diffType">The type of form validation difference to check when processing the images.</param>
        /// <param name="folderPath">The folder path where the images will be saved.</param>
        private void AddScreenshots(RestResponse imageResponse, string fileType, int page, FormValidationType diffType, string folderPath)
        {
            var filePath = Path.Combine(folderPath, $"{fileType}_{diffType}_page_{page}.png");
            File.WriteAllBytes(filePath, imageResponse.RawBytes);

            if (File.Exists(filePath) && new FileInfo(filePath).Length > 0)
            {
                var tempFileType = fileType == "Base" ? "Actual" : "Base";
                var tempFilePath = Path.Combine(folderPath, $"{tempFileType}_{diffType}_page_{page}.png");
                if (File.Exists(tempFilePath))
                {
                    using var image1 = LoadBitmap(filePath);
                    using var image2 = LoadBitmap(tempFilePath);
                    var combinedImage = CombineImagesSideBySide(image1, image2);
                    var combinedFilePath = Path.Combine(folderPath, $"Images_{diffType}_page_{page}.png");
                    SaveBitmapAsPng(combinedImage, combinedFilePath);

                    if (File.Exists(combinedFilePath) && new FileInfo(combinedFilePath).Length > 0)
                    {
                        var combinedFullpath = Path.Combine(Directory.GetCurrentDirectory(), combinedFilePath);
                        logger.WriteLine($"file:///{combinedFullpath}");
                    }
                    else
                    {
                        logger.WriteLine($"Failed to write combined file or file is empty: {combinedFilePath}");
                    }
                }
            }
            else
            {
                logger.WriteLine($"Failed to write file or file is empty: {filePath}");
            }
        }

        private bool GetToken()
        {
            var authRequest = new RestRequest("api-token-auth/");
            authRequest.AddHeader("Content-Type", "application/json");
            var body = new { username = userName, password = passWord };
            authRequest.AddJsonBody(body);
            var response = restAPIHelper.PostRequest(authRequest);
            if (response.IsSuccessful)
            {
                var jsonResponse = JObject.Parse(response.Content);
                authToken = jsonResponse["token"].ToString();
                tokenExpiryTime = DateTime.Now.AddMinutes(60);
                logger.WriteLine("Authentication successful");
                return true;
            }
            else
            {
                logger.WriteLine("Error in authentication. Status code: " + response.StatusCode);
                return false;
            }
        }

        private bool Authentication() => (!string.IsNullOrEmpty(authToken) && DateTime.Now < tokenExpiryTime) || GetToken();
    }
}