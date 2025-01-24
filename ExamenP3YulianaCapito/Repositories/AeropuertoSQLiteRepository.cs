using ExamenP3YulianaCapito.Interfaces;
using ExamenP3YulianaCapito.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenP3YulianaCapito.Repositories
{
    public class AeropuertoSQLiteRepository : IAreopuertoRepository
    {
        private readonly string _dbPath = Path.Combine(FileSystem.AppDataDirectory, "AreopuertosYC.db3");
        private SQLiteConnection _connection;
        public AeropuertoSQLiteRepository()
        {
            Init(); 
        }
        public void Init()
        {
            _connection = new SQLiteConnection(_dbPath);
            _connection.CreateTable<AreopuertoYC>();
        }

        public List<AreopuertoYC> BuscarAreopuertos(string busqueda)
        {
            throw new NotImplementedException();
        }

        public void GuardarAeropuertos(List<AreopuertoYC> aeropuertos)
        {
            foreach (var aeropuerto in aeropuertos)
            {
                _connection.Insert(aeropuerto);
            }
        }

        public List<AreopuertoYC> ObtenerAeropuertosGuardados()
        {
            return _connection.Table<AreopuertoYC>().ToList();
        }
    }
}
