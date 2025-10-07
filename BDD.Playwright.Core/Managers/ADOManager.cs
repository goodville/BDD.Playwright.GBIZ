namespace BDD.Playwright.Core.Helpers
{
    using System;
    using BDD.Playwright.Core.Loggers;
    using Newtonsoft.Json.Linq;
    using RestSharp;

    /// <summary>
    /// ADO Manager.
    /// </summary>
    public class ADOManager
    {
        /// <summary>
        /// ADO Organization name.
        /// </summary>
        public static readonly string Organization = "ValueMomentum-QualityLeap";

        /// <summary>
        /// ADO Project name.
        /// </summary>
        public static readonly string Project = "Asset%20Migration%20-%20Cognitive";

        /// <summary>
        /// ADO Team name.
        /// </summary>
        public static readonly string Team = "iTAP";

        /// <summary>
        /// ADO Personal Access Token.
        /// </summary>
        public static readonly string Pat = "jeroxnph7wukiqigsnqw7ethf2xk3ow36behqvacgx23jwl6ztva";

        /// <summary>
        /// Gets the Sprint Name from ADO
        /// </summary>
        /// <returns>string</returns>
        public static string GetADOSprintName()
        {
            var sprintName = string.Empty;
            var uri = $"https://dev.azure.com/{Organization}/{Project}/{Team}/_apis/work/teamsettings/iterations?$timeframe=current&api-version=6.0";

            try
            {
                var client = new RestClient(uri);
                var request = new RestRequest(uri, Method.Get);
                var base64Pat = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($":{Pat}"));
                request.AddHeader("Authorization", $"Basic {base64Pat}");
                request.AddHeader("Accept", "application/json");
                var response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    var jsonResponse = JObject.Parse(response.Content);

                    // Assuming there's only one current sprint
                    if (jsonResponse["value"] != null && jsonResponse["value"].HasValues)
                    {
                        var currentSprint = jsonResponse["value"][0];
                        sprintName = currentSprint["name"].ToString();
                        CustomLogger.WriteLine($"Current Sprint Name: {sprintName}");
                    }
                    else
                    {
                        CustomLogger.WriteLine("No current sprint found.");
                    }
                }
            }
            catch (Exception ex)
            {
                CustomLogger.WriteLine($"Error Message: {ex.Message}");
            }

            return sprintName;
        }
    }
}
