using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Builder.HttpRequest
{
    public class HttpRequestBuilder
    {
        private string _method = "GET";
        private string _url = "";
        private Dictionary<string, string> _headers = new Dictionary<string, string>();
        private string _body = "";

        public HttpRequestBuilder SetMethod(string method)
        {
            _method = method.ToUpper();
            return this;
        }

        public HttpRequestBuilder SetUrl(string url) 
        { 
            _url = url; 
            return this; 
        }

        public HttpRequestBuilder SetBody(string body)
        {
            _body = body;
            return this;
        }

        public HttpRequestBuilder AddHeader(string key, string value)
        {
            _headers[key] = value;
            return this;
        }

        public  HttpRequest Build()
        {
            return new HttpRequest(_method, _url, _headers, _body);
        }

    }
}
