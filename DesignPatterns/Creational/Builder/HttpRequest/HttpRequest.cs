using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Builder.HttpRequest
{
    public class HttpRequest
    {
        public string Method { get; }
        public string Url { get; }
        public Dictionary<string, string> Headers { get; }
        public string Body { get; }

        public HttpRequest(string method, string url, Dictionary<string, string> headers, string body)
        {
            Method = method;
            Url = url;
            Headers = headers;
            Body = body;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Method} {Url}");
            foreach (var header in Headers)
                sb.AppendLine($"{header.Key}: {header.Value}");
            if (!string.IsNullOrEmpty(Body))
                sb.AppendLine($"\n{Body}");
            return sb.ToString();
        }
    }
}
