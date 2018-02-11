using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExplainThisCrypto.Models
{
    public class Price
    {
        public int BTC { get; set; }
        public int USD { get; set; }
        public int EUR { get; set; }


        public Price()
        {
        }

        public static Price GetPrice(string symbol)
        {

            var client = new RestClient("https://min-api.cryptocompare.com/data/");
            var request = new RestRequest("price?fsym=" + symbol + "&tsyms=BTC,USD,EUR", Method.GET);
            var response = new RestResponse();
            Task.Run(async () =>
            {

                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var CoinPrice = JsonConvert.DeserializeObject<Price>(jsonResponse["price"].ToString());
            return CoinPrice;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
