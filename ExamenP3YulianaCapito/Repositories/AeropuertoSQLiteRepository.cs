using ExamenP3YulianaCapito.Interfaces;
using ExamenP3YulianaCapito.Models;
using Newtonsoft.Json;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExamenP3YulianaCapito.Repositories
{
    public class AeropuertoSQLiteRepository : IAreopuertoRepository
    {
        private readonly string _dbPath = Path.Combine(FileSystem.AppDataDirectory, "AeropuertosYC.db3");
        private SQLiteConnection _connection;

        public AeropuertoSQLiteRepository()
        {
            InitSQLite();
        }

        private void InitSQLite()
        {
            _connection = new SQLiteConnection(_dbPath);
            _connection.CreateTable<HistorialYC>();
        }

        public void GuardarAeropuertos(List<HistorialYC> aeropuertos)
        {
            _connection.InsertAll(aeropuertos);
        }

        public List<HistorialYC> ObtenerAeropuertosGuardados()
        {
            return _connection.Table<HistorialYC>().ToList();
        }
        public List<AreopuertoYC> BuscarAreopuertos(string busqueda)
        {
            throw new System.NotImplementedException("Esta funcionalidad no está implementada en el repositorio de SQLite.");
        }
    }
}