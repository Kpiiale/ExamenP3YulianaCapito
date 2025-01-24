using ExamenP3YulianaCapito.Interfaces;
using ExamenP3YulianaCapito.Models;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            _connection.CreateTable<HistorialYC>();
        }

        public List<AreopuertoYC> BuscarAreopuertos(string busqueda)
        {
            return _connection.Table<AreopuertoYC>()
                .Where(a => a.Name.Contains(busqueda) || a.City.Contains(busqueda))
                .ToList();
        }

        public void GuardarAeropuertos(List<HistorialYC> aeropuertos)
        {
            foreach (var aeropuerto in aeropuertos)
            {
                _connection.Insert(aeropuerto);
            }
        }

        public List<HistorialYC> ObtenerAeropuertosGuardados()
        {
            return _connection.Table<HistorialYC>().ToList();
        }
    }
}
