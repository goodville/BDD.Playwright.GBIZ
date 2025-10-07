namespace BDD.Playwright.Core.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using BDD.Playwright.Core.Configuration;
    using BDD.Playwright.Core.Enums;
    using BDD.Playwright.Core.Loggers;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    using RestSharp;
    using SkiaSharp;

    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class FormValidationHelper
    {
        private readonly RestClient client;
        private readonly string baseUrl;
        public string AccessToken;
        public string FolderPath;
        public bool Completematch;
        private static readonly string[] Separator = new[] { "," };

        public FormValidationHelper()
        {
            baseUrl = GlobalConfig.Settings.PDFCompareUrls.ItapBaseUrl;
            client = new RestClient(baseUrl);
        }

        /// <summary>
        /// Represents a class for interacting with an external API
        /// And provides a method for obtaining the access token by making an API request.
        /// </summary>
        public void GenerateToken()
        {
            var resource = "/identity-service/auth";
            var request = new RestRequest(resource, Method.Post);
            request.AddParameter("client_id", "resource_owner_flow");
            request.AddParameter("client_secret", "resource_owner_flow_secret");
            request.AddParameter("scope", "openid");
            request.AddParameter("username", "admin@valuemomentum.com");
            request.AddParameter("password", "6m/gsQ5Ghij6E2E2GHs9Gw==");
            request.AddParameter("grant_type", "password");

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                AccessToken = GetAccessToken(response.Content);
                CustomLogger.WriteLine("Access Token: " + AccessToken);
            }
            else
            {
                CustomLogger.WriteLine("Request failed with status code: " + response.StatusCode);
            }
        }

        /// <summary>
        /// Gets Access Token.
        /// </summary>
        /// <param name="responseContent"><response content./param>
        /// <returns>string.</returns>
        private static string GetAccessToken(string responseContent)
        {
            var jsonResponse = JObject.Parse(responseContent);
            return jsonResponse["access_token"].ToString();
        }

        /// <summary>
        /// Represents a class for interacting with an external API
        /// We will pass the access token to this method and use the external Api for form validation.
        /// </summary>
        /// <param name="filePaths"></param>
        /// <param name="baseFileData"></param>
        /// <param name="actualFileData"></param>
        /// <param name="diffType"></param>
        /// <returns></returns>
        public RestResponse UploadFile(byte[] baseFileData, byte[] actualFileData, FormValidationType diffType)
        {
            return InvokePDFCompare(baseFileData, actualFileData, diffType);
        }

        public RestResponse UploadCustomIgnoreDynamicContent(byte[] baseFileData, byte[] actualFileData, FormValidationType diffType, bool standardform)
        {
            return InvokePDFCompare(baseFileData, actualFileData, diffType, standardform);
        }

        public RestResponse UploadStandardIgnoreDynamicContent(byte[] baseFileData, byte[] actualFileData, FormValidationType diffType, bool standardform, string prefix, string suffix)
        {
            return InvokePDFCompare(baseFileData, actualFileData, diffType, standardform, prefix, suffix);
        }

        public RestResponse UploadStandardValidateDynamicContent(byte[] baseFileData, byte[] actualFileData, FormValidationType diffType, bool standardform, string prefix, string suffix, byte[] exceldata)
        {
            return InvokePDFCompare(baseFileData, actualFileData, diffType, standardform, prefix, suffix, exceldata);
        }

        public RestResponse UploadCustomValidateDynamicContent(byte[] baseFileData, byte[] actualFileData, FormValidationType diffType, byte[] exceldata, bool standardform)
        {
            return InvokePDFCompare(baseFileData, actualFileData, diffType, standardform, excelFile: exceldata);
        }

        public static void ValidateUploadResponse(RestResponse response)
        {
            CustomLogger.WriteLine(response.Content.ToString());

            var jsonObject = JObject.Parse(response.Content);
            var completematch = (bool)jsonObject["isCompleteMatch"];
            if (completematch)
            {
                Assert.IsTrue(completematch, "Complete Match is found.");
            }
            else
            {
                Assert.IsFalse(completematch, "Complete Match is NOT found.");
            }
        }

        public static void ValidateStatusCode(RestResponse response)
        {
            CustomLogger.WriteLine(response.StatusCode.ToString());
            if (response.StatusCode == HttpStatusCode.OK)
            {
                CustomLogger.WriteLine("Status Code is Ok");
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Status Code should be OK");
            }
            else
            {
                CustomLogger.WriteLine("Error Occurred in the Status Code");
                Assert.Fail($"Unexpected status code: {response.StatusCode}");
            }
        }

        public RestResponse UploadBatchFile(string basefiles, string actualfiles)
        {
            if (string.IsNullOrEmpty(AccessToken))
            {
                CustomLogger.WriteLine("Access token is not available");
                return null;
            }

            var baseFiles = basefiles.Split(Separator, StringSplitOptions.RemoveEmptyEntries);
            var actualFiles = actualfiles.Split(Separator, StringSplitOptions.RemoveEmptyEntries);

            var files = new List<FileInfo>();
            AddPdfFiles(files, baseFiles);
            AddPdfFiles(files, actualFiles);

            if (files.Count == 0)
            {
                CustomLogger.WriteLine("No files to upload");
                return null;
            }

            var uploadResource = "/formvalidation-api/api/BatchCompare/uploadPDF";
            var uploadRequest = new RestRequest(uploadResource, Method.Post);
            uploadRequest.AddHeader("Authorization", "Bearer " + AccessToken);
            uploadRequest.AddParameter("userName", "admin");

            foreach (var file in files)
            {
                uploadRequest.AddFile("file", file.FullName, "application/pdf");
            }

            var uploadResponse = client.Execute(uploadRequest);
            return uploadResponse;
        }

        private static void AddPdfFiles(List<FileInfo> fileList, string[] filePaths)
        {
            foreach (var filePath in filePaths)
            {
                CustomLogger.WriteLine($"Processing file path: {filePath}");
                var file = new FileInfo(filePath);

                if (file.Exists)
                {
                    // _logger.Output.WriteLine($"File exists: {filePath}");
                    if (file.Extension.Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                    {
                        fileList.Add(file);
                        CustomLogger.WriteLine($"Added PDF file: {filePath}");
                    }
                    else
                    {
                        CustomLogger.WriteLine($"File is not a PDF: {filePath}");
                    }
                }
                else
                {
                    CustomLogger.WriteLine($"File does not exist: {filePath}");
                }
            }
        }

        public RestResponse ValidateImage(RestResponse response, FormValidationType diffType)
        {
            var uploadResource = "/formvalidation-api/OneToOne/getImage";
            CustomLogger.WriteLine(response.StatusCode.ToString());
            var contentObject = JObject.Parse(response.Content.ToString());
            var baseImagePath = "FormsValidation\\Images";
            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            FolderPath = Path.Combine(baseImagePath, timestamp);
            Directory.CreateDirectory(FolderPath);
            if (contentObject.ContainsKey("baseData"))
            {
                var baseData = (JObject)contentObject["baseData"];
                ImageCheck(diffType, uploadResource, baseData, "fileName", "Base");
            }

            if (contentObject.ContainsKey("actualData"))
            {
                var actualData = (JObject)contentObject["actualData"];
                ImageCheck(diffType, uploadResource, actualData, "fileName", "Actual");
            }

            return response;
        }

        private void ImageCheck(FormValidationType diffType, string uploadResource, JObject obj, string path, string resource)
        {
            var baseFilePath = obj[path].ToString();
            CustomLogger.WriteLine(path + ":" + baseFilePath);
            var totalPages = 0;
            if (obj.ContainsKey("pageCount"))
            {
                var page = Convert.ToInt32(obj["pageCount"]);
                totalPages = page;
            }

            for (var i = 1; i <= totalPages; i++)
            {
                CustomLogger.WriteLine("page:" + i);
                var uRL = uploadResource + "/" + baseFilePath + "/" + resource + "/" + i + "/" + diffType;
                CustomLogger.WriteLine(uRL);
                var uploadRequest = new RestRequest(uRL, Method.Get);
                var uploadResponse = client.Execute(uploadRequest);
                File.WriteAllBytes(Path.Combine(FolderPath, $"{resource}_Images_{diffType}_{i}.jpeg"), uploadResponse.RawBytes);
            }
        }

        public void AddScreenshots(FormValidationType diffType)
        {
            if (Directory.Exists(FolderPath))
            {
                var imageFiles = Directory.GetFiles(FolderPath, "*.jpeg");

                var actualFiles = imageFiles.Where(f => f.Contains("Actual_Images")).ToList();
                var baseFiles = imageFiles.Where(f => f.Contains("Base_Images")).ToList();

                var maxIterations = Math.Max(actualFiles.Count, baseFiles.Count);
                var width = 1000;
                var height = 1550;
                var imageCounter = 1;

                for (var i = 0; i < maxIterations; i++)
                {
                    var actualPath = i < actualFiles.Count ? actualFiles[i] : string.Empty;
                    var actualBitmap = string.IsNullOrEmpty(actualPath) ? null : SKBitmap.Decode(actualPath);

                    var basePath = i < baseFiles.Count ? baseFiles[i] : string.Empty;
                    var baseBitmap = string.IsNullOrEmpty(basePath) ? null : SKBitmap.Decode(basePath);

                    var resizedActualBitmap = ResizeBitmap(actualBitmap, width, height);
                    var resizedBaseBitmap = ResizeBitmap(baseBitmap, width, height);

                    var combinedBitmap = CombineImages(resizedActualBitmap, resizedBaseBitmap);
                    var tempFileName = $"Images_{imageCounter}_{diffType}.png";
                    var tempFilePath = Path.Combine(Path.GetTempPath(), tempFileName);
                    using (var image = SKImage.FromBitmap(combinedBitmap))
                    using (var data = image.Encode(SKEncodedImageFormat.Png, 100)) // Change to PNG format
                    using (var stream = File.OpenWrite(tempFilePath))
                    {
                        data.SaveTo(stream);
                    }

                    imageCounter++;
                    var fullpathCombined = Path.Combine(Directory.GetCurrentDirectory(), tempFilePath);
                    var url = $"file:///{fullpathCombined}";
                    CustomLogger.WriteLine($"SCREENSHOT[ file:///{fullpathCombined} ]SCREENSHOT");

                    actualBitmap?.Dispose();
                    baseBitmap?.Dispose();
                    resizedActualBitmap?.Dispose();
                    resizedBaseBitmap?.Dispose();
                    combinedBitmap.Dispose();
                }
            }
        }

        // Function to combine two images side-by-side
        private static SKBitmap ResizeBitmap(SKBitmap bitmap, int width, int height)
        {
            return bitmap == null ? null : bitmap.Resize(new SKImageInfo(width, height), SKFilterQuality.High);
        }

        private static SKBitmap CombineImages(SKBitmap bitmap1, SKBitmap bitmap2)
        {
            if (bitmap1 == null && bitmap2 == null)
            {
                throw new ArgumentException("Both images cannot be null");
            }

            var width = (bitmap1?.Width ?? 0) + (bitmap2?.Width ?? 0);
            var height = Math.Max(bitmap1?.Height ?? 0, bitmap2?.Height ?? 0);

            var combinedBitmap = new SKBitmap(width, height);
            using (var canvas = new SKCanvas(combinedBitmap))
            {
                if (bitmap1 != null)
                {
                    canvas.DrawBitmap(bitmap1, 0, 0);
                }

                if (bitmap2 != null)
                {
                    canvas.DrawBitmap(bitmap2, bitmap1?.Width ?? 0, 0);
                }
            }

            return combinedBitmap;
        }

        private RestResponse InvokePDFCompare(
            byte[] baseFile,
            byte[] actualFile,
            FormValidationType diffType,
            bool standardform = default,
            string prefix = default,
            string suffix = default,
            byte[] excelFile = null)
        {
            if (string.IsNullOrEmpty(AccessToken))
            {
                CustomLogger.WriteLine("Access token is not available");
                return null;
            }
            else
            {
                var uploadResource = "/formvalidation-api/OneToOne/compare";
                var uploadRequest = new RestRequest(uploadResource, Method.Post);
                uploadRequest.AddHeader("Authorization", "Bearer " + AccessToken);

                // FormValidationType.P2P, FormValidationType.TS, FormValidationType.CT, FormValidationType.FC
                uploadRequest.AddParameter("diffType", diffType.ToString().ToLower());
                uploadRequest.AddFile("baseFile", baseFile, "baseFile.pdf", "application/pdf");
                uploadRequest.AddFile("actualFile", actualFile, "actualFile.pdf", "application/pdf");

                if (diffType == FormValidationType.CT || diffType == FormValidationType.ALL)
                {
                    uploadRequest.AddParameter("applySorting", true);
                }
                else if (diffType == FormValidationType.IDC)
                {
                    if (standardform)
                    {
                        uploadRequest.AddParameter("Prefix", prefix);
                        uploadRequest.AddParameter("Suffix", suffix);
                    }

                    uploadRequest.AddParameter("standardform", standardform);
                }
                else if (diffType == FormValidationType.VDC)
                {
                    if (standardform)
                    {
                        uploadRequest.AddParameter("Prefix", prefix);
                        uploadRequest.AddParameter("Suffix", suffix);
                    }

                    uploadRequest.AddParameter("standardform", standardform);
                    uploadRequest.AddFile("ExcelFile", excelFile, "Exceldata.xlsx");
                }

                var uploadResponse = client.Execute(uploadRequest);
                return uploadResponse;
            }
        }
    }
}
