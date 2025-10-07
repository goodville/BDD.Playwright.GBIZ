namespace BDD.Playwright.Core.Helpers
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using BDD.Playwright.Core.Configuration;
    using BDD.Playwright.Core.Loggers;
    using BDD.Playwright.Core.Models.SaveTestResultModels;
    using Newtonsoft.Json;

    public class SaveTestResults
    {
        private SaveTestResults()
        {
        }

        public static async Task<bool> SaveResults(SaveTestResultRequest saveTestResultRequest)
        {
            try
            {
                using var httpClient = new HttpClient();
                var baseUrl = GlobalConfig.Settings.DashboardURL;
                var json = JsonConvert.SerializeObject(saveTestResultRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(baseUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    CustomLogger.WriteLine($"StatusCode: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                CustomLogger.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
}