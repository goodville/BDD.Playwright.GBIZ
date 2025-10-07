namespace BDD.Playwright.Core.Helpers
{
    using RestSharp;

    /// <summary>
    /// Provides helper methods for performing REST API calls using RestSharp.
    /// </summary>
    public class RestAPIHelper
    {
        private readonly RestClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestAPIHelper"/> class with the specified base URL.
        /// </summary>
        /// <param name="baseUrl">The base URL for the REST API.</param>
        public RestAPIHelper(string baseUrl)
        {
            client = new RestClient(baseUrl);
        }

        /// <summary>
        /// Gets the underlying <see cref="RestClient"/>.
        /// </summary>
        /// <returns>The configured <see cref="RestClient"/> instance.</returns>
        public RestClient GetClient() => client;

        /// <summary>
        /// Executes a POST request with the specified <see cref="RestRequest"/>.
        /// </summary>
        /// <param name="request">The <see cref="RestRequest"/> to execute.</param>
        /// <returns>A <see cref="RestResponse"/> representing the response.</returns>
        public RestResponse PostRequest(RestRequest request)
        {
            request.Method = Method.Post;
            return client.Execute(request);
        }

        /// <summary>
        /// Executes a GET request with the specified <see cref="RestRequest"/>.
        /// </summary>
        /// <param name="request">The <see cref="RestRequest"/> to execute.</param>
        /// <returns>A <see cref="RestResponse"/> representing the response.</returns>
        public RestResponse GetRequest(RestRequest request)
        {
            request.Method = Method.Get;
            return client.Execute(request);
        }

        /// <summary>
        /// Executes a PUT request with the specified <see cref="RestRequest"/>.
        /// </summary>
        /// <param name="request">The <see cref="RestRequest"/> to execute.</param>
        /// <returns>A <see cref="RestResponse"/> representing the response.</returns>
        public RestResponse PutRequest(RestRequest request)
        {
            request.Method = Method.Put;
            return client.Execute(request);
        }

        /// <summary>
        /// Executes a DELETE request with the specified <see cref="RestRequest"/>.
        /// </summary>
        /// <param name="request">The <see cref="RestRequest"/> to execute.</param>
        /// <returns>A <see cref="RestResponse"/> representing the response.</returns>
        public RestResponse DeleteRequest(RestRequest request)
        {
            request.Method = Method.Delete;
            return client.Execute(request);
        }
    }
}
