using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;

namespace NavigatingAzure.Pages
{
    public class HybridModel : PageModel
    {

        private static HttpClient client = new HttpClient();

        [BindProperty]
        public string HybridMessage { get; set; }

        public async void OnGet()
        {
            HybridMessage = " ... loading";
            HybridMessage = await GetHybridDataAsync("http://josh-dev:44359/api/hybrid/request");  
            HybridMessage = HybridMessage + " .. Finished";   

            ViewData["HybridMessage"] = HybridMessage;
        }

        static async Task<String> GetHybridDataAsync(string path)
        {
            string message = string.Empty;

            try
            {

                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    message = await response.Content.ReadAsStringAsync();

                    if(String.IsNullOrEmpty(message)){
                        message = "empty";
                    }
                }
                else{
                    message = "Hybrid Request Failure";
                }
            }
            catch(Exception ex){
                message = "Hybrid Request Failure: " + ex.Message;
            }
            
            return message;
        }

    }
}
