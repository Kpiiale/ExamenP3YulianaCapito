using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL; 

namespace ExamenP3YulianaCapito.Models
{
    public class HistorialYC
    {
        [PrimaryKey, AutoIncrement] 
        public int Id { get; set; } 
        public string NameH { get; set; }
        public string CityH { get; set; }
        public string CountryH { get; set; }
    }
}
