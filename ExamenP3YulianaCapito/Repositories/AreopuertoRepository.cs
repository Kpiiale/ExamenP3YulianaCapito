using ExamenP3YulianaCapito.Interfaces;
using ExamenP3YulianaCapito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Net.Http;

namespace ExamenP3YulianaCapito.Repositories
{
    internal class AreopuertoRepository : IAreopuertoRepository
    {
        public HttpClient _httpClient;
        
        public AreopuertoRepository()
        {
            _httpClient = new HttpClient(); 
        }

        public List<AreopuertoYC> BuscarAreopuertos(string busqueda)
        {
            var url = $"https://freetestapi.com/api/v1/airports?search={busqueda}";
            var response = _httpClient.GetStringAsync(url).GetAwaiter().GetResult();
            var aeropuertos = JsonConvert.DeserializeObject<List<AreopuertoYC>>(response);
            return aeropuertos ?? new List<AreopuertoYC>();

        }
    }
}
