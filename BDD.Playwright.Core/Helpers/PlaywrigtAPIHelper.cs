namespace BDD.Playwright.Core.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BDD.Playwright.Core.Configuration;
    using BDD.Playwright.Core.Interfaces;
    using BDD.Playwright.Core.Loggers;
    using Microsoft.Playwright;

    public class PlaywrightApiHelper
    {
        private readonly IAPIRequestContext apiContext;
        private readonly IAuthenticationStrategy authStrategy;
        private readonly Uri baseURL;
        private readonly ApplicationLogger logger;

        public PlaywrightApiHelper(IAPIRequestContext apiContext, IAuthenticationStrategy authStrategy, ApplicationLogger logger)
        {
            this.apiContext = apiContext;
            this.authStrategy = authStrategy;

            var guidewireProduct = GlobalConfig.Settings.Products.FirstOrDefault(p => p.Name.Equals(GlobalConfig.Settings.ProductName));
            if (guidewireProduct != null && guidewireProduct.Environments.ContainsKey(GlobalConfig.Settings.Environment))
            {
                // Access the PolicyCenter URL within the QA environment
                baseURL = new Uri(guidewireProduct.Environments[GlobalConfig.Settings.Environment].ProductSuites["PolicyCenter"].ApiEndpoint);
            }

            this.logger = logger;
            logger.WriteLine($"Authentication type:{authStrategy.GetType().Name}");
        }

        private async Task<Dictionary<string, string>> GetAuthHeadersAsync() => authStrategy != null ? await authStrategy.GetAuthHeadersAsync() : [];

        public async Task<IAPIResponse> GetAsync(string endpoint)
        {
            var headers = await GetAuthHeadersAsync();
            logger.WriteLine($"Get API URL :{new Uri(baseURL, endpoint).ToString()}");
            logger.WriteLine($"_baseURL: {baseURL.ToString()}");
            logger.WriteLine($"endPoint: {endpoint}");
            logger.WriteLine($"endPoint: {new Uri(baseURL, endpoint).ToString()}");

            return await apiContext.GetAsync(new Uri(baseURL, endpoint).ToString(), new APIRequestContextOptions { Headers = headers });
        }

        public async Task<IAPIResponse> PostAsync(string endpoint, object data)
        {
            var headers = await GetAuthHeadersAsync();
            logger.WriteLine($"Post API URL :{new Uri(baseURL, endpoint).ToString()}");
            logger.WriteLine($"Data :{data.ToString()}");
            return await apiContext.PostAsync(new Uri(baseURL, endpoint).ToString(), new APIRequestContextOptions { DataObject = data, Headers = headers });
        }

        public async Task<IAPIResponse> PutAsync(string endpoint, object data)
        {
            var headers = await GetAuthHeadersAsync();
            logger.WriteLine($"PUT API URL :{new Uri(baseURL, endpoint).ToString()}");
            logger.WriteLine($"Data :{data.ToString()}");
            return await apiContext.PutAsync(new Uri(baseURL, endpoint).ToString(), new APIRequestContextOptions { DataObject = data, Headers = headers });
        }

        public async Task<IAPIResponse> DeleteAsync(string endpoint)
        {
            var headers = await GetAuthHeadersAsync();
            logger.WriteLine($"Delete API URL :{new Uri(baseURL, endpoint).ToString()}");
            return await apiContext.DeleteAsync(new Uri(baseURL, endpoint).ToString(), new APIRequestContextOptions { Headers = headers });
        }
    }
}
