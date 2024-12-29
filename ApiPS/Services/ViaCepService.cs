using ApiPS.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using System.Net.Http;

namespace ApiPS.Services
{
    public class ViaCepService
    {

        private readonly HttpClient _httpClient;
        ViaCepService( ) 
        {
            _httpClient = new HttpClient();

            
        }

        public async Task<ViaCepModel> ConsultaCep(int cep)
        {
            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");


            string resultJS = await response.Content.ReadAsStringAsync();
            ViaCepModel result = JsonConvert.DeserializeObject<ViaCepModel>(resultJS);
            Console.WriteLine(result);

            return result;

        }


    }






    }

