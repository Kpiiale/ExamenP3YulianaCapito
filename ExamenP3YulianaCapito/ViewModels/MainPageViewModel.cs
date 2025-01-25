using ExamenP3YulianaCapito.Interfaces;
using ExamenP3YulianaCapito.Models;
using ExamenP3YulianaCapito.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ExamenP3YulianaCapito.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly IAreopuertoRepository _repositorioAPI;
        private readonly IAreopuertoRepository _repositorioSQLite;

        private string _terminoBusqueda;
        private string _resultado;
        private List<AreopuertoYC> _aeropuertos;

        public ICommand CommandBuscarAeropuertos { get; set; }
        public ICommand CommandCargarHistorial { get; set; }

        public string TerminoBusqueda
        {
            get => _terminoBusqueda;
            set
            {
                if (_terminoBusqueda != value)
                {
                    _terminoBusqueda = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<AreopuertoYC> Areopuertos
        {
            get => _aeropuertos;
            set
            {
                if (_aeropuertos != value)
                {
                    _aeropuertos = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Resultado
        {
            get => _resultado;
            set
            {
                if (_resultado != value)
                {
                    _resultado = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainPageViewModel()
        {
            _repositorioAPI = new AreopuertoRepository();
            _repositorioSQLite = new AeropuertoSQLiteRepository();

            CommandBuscarAeropuertos = new Command(BuscarAeropuertos);
            CommandCargarHistorial = new Command(CargarHistorial);

            Areopuertos = new List<AreopuertoYC>();
        }

        public void BuscarAeropuertos()
        {
            if (!string.IsNullOrWhiteSpace(TerminoBusqueda))
            {
                try
                {
                    var resultados = _repositorioAPI.BuscarAreopuertos(TerminoBusqueda);

                    if (resultados != null && resultados.Any())
                    {
                        Areopuertos = resultados;
                        var aeropuerto = resultados.First();
                        Resultado = $"Aeropuerto encontrado: {aeropuerto.Name} ({aeropuerto.City}).";

                        var historial = resultados.Select(a => new HistorialYC
                        {
                            NameH = a.Name,
                            CityH = a.City,
                            CountryH = a.Country,
                        }).ToList();

                        _repositorioSQLite.GuardarAeropuertos(historial);
                    }
                    else
                    {
                        Areopuertos = new List<AreopuertoYC>();
                        Resultado = "No se encontraron aeropuertos con ese término de búsqueda.";
                    }
                }
                catch (Exception ex)
                {
                    Resultado = $"Error al buscar aeropuertos: {ex.Message}";
                }
            }
            else
            {
                Resultado = "Por favor, ingrese un término de búsqueda.";
            }
        }

        public void CargarHistorial()
        {
            try
            {
                
                var historial = _repositorioSQLite.ObtenerAeropuertosGuardados();
                Areopuertos = historial.Select(h => new AreopuertoYC
                {
                    Name = h.NameH,
                    City = h.CityH,
                    Country = h.CountryH,
                }).ToList();

                Resultado = "Historial cargado correctamente.";
            }
            catch (Exception ex)
            {
                Resultado = $"Error al cargar historial: {ex.Message}";
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

