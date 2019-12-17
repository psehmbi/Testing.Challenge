using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Testing.Challenge.Models;

namespace Testing.Challenge.Extensions
{
    public static class ApplicantExtensions
    {
        public static async Task<HttpResponseMessage> Submit(this Applicant applicant)
        {
            var request = JsonConvert.SerializeObject(applicant);
            var payload = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(8)
            };
            try
            {
                var response = await client.PostAsync("http://dummydecisionapi.azurewebsites.net/decision", payload);
                if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new Exception("Decision endpoint returned 500");
                }
                return response;
            }
            catch (TaskCanceledException)
            {
                throw new Exception("The decision took longer than 8 seconds");
            }
        }
    }
}
