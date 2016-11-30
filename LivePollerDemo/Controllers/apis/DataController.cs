using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Contracts;
using LivePollerDemo.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LivePollerDemo.Controllers.apis
{
    [EnableCors(origins: "http://localhost:8888", headers:"*", methods:"*")]
    public class DataController : ApiController
    {
        private readonly Random _rand = new Random();
        private readonly GraphDataConsumer _consumer = new GraphDataConsumer();

        [Route("api/Data/get")]
        [HttpGet]
        public string Get()
        {
            try
            {
                var graphData = GraphDataConsumer.Data.Dequeue();

                var jsonSetting = new JsonSerializerSettings() {ContractResolver = new CamelCasePropertyNamesContractResolver()};
                var data = JsonConvert.SerializeObject(graphData, jsonSetting);
            
                return data;
            }
            catch
            {
                return "{ \"pointX\":0,\"pointY\":0 }";
            }
        }
    }
}
