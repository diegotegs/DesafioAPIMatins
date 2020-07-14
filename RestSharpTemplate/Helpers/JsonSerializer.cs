using Newtonsoft.Json;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTemplate.Helpers
{
    public class JsonSerializer : ISerializer
    {
        private string contentType = "application/json";
        public string ContentType { get => contentType; set => contentType = value; }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
