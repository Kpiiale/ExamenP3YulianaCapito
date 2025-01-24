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
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
