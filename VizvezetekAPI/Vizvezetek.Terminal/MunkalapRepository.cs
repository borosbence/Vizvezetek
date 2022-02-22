using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Vizvezetek.DTO;

namespace Vizvezetek.Terminal
{
    public class MunkalapRepository
    {
        private HttpClient client;
        private string path;
        public MunkalapRepository()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            path = "Munkalapok";
        }

        public async Task <List<MunkalapDto>> GetAll()
        {
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
               return await response.Content.ReadAsAsync<List<MunkalapDto>>();
            }
            return null;
        }

        public async Task<MunkalapDto> GetById(int id)
        {
            HttpResponseMessage response = await client.GetAsync(path + "/" + id);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<MunkalapDto>();
            }
            return null;
        }

        public async Task<List<MunkalapDto>> GetAll(MunkalapKeresesDto munkalapKereses)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(path + "/Kereses", munkalapKereses);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<MunkalapDto>>();
            }
            return null;
        }
    }
}
