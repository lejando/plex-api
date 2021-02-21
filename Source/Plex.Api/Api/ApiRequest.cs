using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Linq;

namespace Plex.Api.Api
{
    /// <summary>
    /// Class for issuing Api Requests to Plex Server
    /// </summary>
    public class ApiRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequest"/> class.
        /// </summary>
        /// <param name="endpoint">Endpoint of api request.</param>
        /// <param name="baseUri">Base Uri for api request.</param>
        /// <param name="httpMethod">Http Method to be used for api request.</param>
        /// <param name="requestHeaders">Request Headers for api request.</param>
        /// <param name="contentHeaders">Content Headers for api request.</param>
        /// <param name="body">Body of api request.</param>
        /// <param name="queryParams">Query parameters for api request.</param>
        public ApiRequest(string endpoint, string baseUri, HttpMethod httpMethod,
            Dictionary<string, string> requestHeaders, Dictionary<string, string> contentHeaders, object body,
            Dictionary<string, string> queryParams)
        {
            this.Endpoint = endpoint;
            this.BaseUri = baseUri;
            this.HttpMethod = httpMethod;
            this.RequestHeaders = requestHeaders;
            this.ContentHeaders = contentHeaders;
            this.Body = body;
            this.QueryParams = queryParams;
        }

        /// <summary>
        /// Endpoint of api request
        /// </summary>
        private string Endpoint { get; }

        private string BaseUri { get; }

        /// <summary>
        ///
        /// </summary>
        public HttpMethod HttpMethod { get; }
        /// <summary>
        ///
        /// </summary>
        public Dictionary<string, string> RequestHeaders { get; }
        /// <summary>
        ///
        /// </summary>
        public Dictionary<string, string> ContentHeaders { get; }

        /// <summary>
        ///
        /// </summary>
        public Dictionary<string, string> QueryParams { get; }

        /// <summary>
        ///
        /// </summary>
        public object Body { get; }

        /// <summary>
        ///
        /// </summary>
        public string FullUri
        {
            get
            {
                var uriBuilder = new StringBuilder();

                if (!string.IsNullOrEmpty(BaseUri))
                {
                    uriBuilder.Append(BaseUri.EndsWith("/") ? BaseUri : $"{BaseUri}/");
                }

                if (!string.IsNullOrEmpty(Endpoint))
                {
                    uriBuilder.Append(Endpoint.StartsWith("/") ? Endpoint.Skip(1) : Endpoint);
                }

                AddQueryParams(uriBuilder);

                return uriBuilder.ToString();
            }
        }

        private void AddQueryParams(StringBuilder uriBuilder)
        {
            if (!QueryParams.Any())
            {
                return;
            }

            if (!uriBuilder.ToString().Contains("?"))
            {
                uriBuilder.Append("?");
            }

            for (var i = 0; i < QueryParams.Count; i++)
            {
                var (key, value) = QueryParams.ElementAt(i);

                uriBuilder.Append($"{key}={value}");

                var isLast = i == QueryParams.Count - 1;

                if (!isLast)
                {
                    uriBuilder.Append("&");
                }
            }
        }
    }
}