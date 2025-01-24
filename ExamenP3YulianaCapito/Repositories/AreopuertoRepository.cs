using ExamenP3YulianaCapito.Interfaces;
using ExamenP3YulianaCapito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; 

namespace ExamenP3YulianaCapito.Repositories
{
    internal class AreopuertoRepository : IAreopuertoRepository
    {
        public HttpClient _httpClient;
        public string endpoint = "https://www.freetestapi.com/api/v1/airports?search=Singapore";

        public AreopuertoRepository()
        {
            _httpClient = new HttpClient(); 
        }
        public AreopuertoYC DevuelveInfoAreopuerto(int Id)
        {
            throw new NotImplementedException();
        }

        public List<AreopuertoYC> DevuelveListaAreopuertos()
        {
            throw new NotImplementedException();
        }
    }
}
