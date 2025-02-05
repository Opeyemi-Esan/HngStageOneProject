using HngStageOneProject.Models;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace HngStageOneProject.Services
{
    public class NumberService : INumberService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NumberService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ApiResponse<NumberProperties>> ClassifyNumber(int number)
        {
            var properties = new List<string>();

            if (IsArmstrong(number)) properties.Add("armstrong");
            if (number % 2 != 0) properties.Add("odd");

            var funFact = await GetFunFact(number);

            if(funFact == null)
            {
                return new ApiResponse<NumberProperties>
                {
                    Data = null,
                    Message = "Fun fact not found for the specified number.",
                    StatusCode = HttpStatusCode.NotFound,
                    Success = false
                };
            }

            var data = new NumberProperties()
            {
                Number = number,
                IsPrime = IsPrime(number),
                IsPerfect = IsPerfect(number),
                Properties = properties,
                DigitSum = DigitSum(number),
                FunFact = funFact
            };

            return new ApiResponse<NumberProperties>
            {
                Data = data,
                Message = "Number classified successfully.",
                StatusCode = HttpStatusCode.OK,
                Success = true
            };
        }

        private bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        private bool IsPerfect(int n)
        {
            int sum = 0;
            for (int i = 1; i < n; i++)
            {
                if (n % i == 0) sum += i;
            }
            return sum == n;
        }

        private bool IsArmstrong(int n)
        {
            int digitCount = n.ToString().Length;
            int sum = (int)n.ToString()
                        .Select(d => Math.Pow(d - '0', digitCount))
                        .Sum();
            return sum == n;
        }

        private int DigitSum(int n)
        {
            return n.ToString().Select(d => int.Parse(d.ToString())).Sum();
        }

        private async Task<string?> GetFunFact(int n)
        {
            using var client = _httpClientFactory.CreateClient();
            try
            {
                var response = await client.GetStringAsync($"http://numbersapi.com/{n}?json");
                var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<FunFactResponse>(response);

                return jsonResponse?.Text; 
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

    }
}
