using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Dynamic_Currency_Converter
{
    class APIRequester
    {
        private string url;
        private WebClient client;

        public APIRequester(string url)
        {
            this.url = url;
            client = new WebClient();
        }

        public string SendAndGetResponse()
        {
            return client.DownloadString(url);
        }
    }
}