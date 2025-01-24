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
        private IAreopuertoRepository _repositorio;
        private string _terminoBusqueda;
        private string _resultado;
        private List<AreopuertoYC> _aeropuertos;

        public ICommand CommandBuscarAeropuertos { get; set; }
        public ICommand CommandGuardarHistorial { get; set; }

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
            _repositorio = new AeropuertoSQLiteRepository();
            CommandBuscarAeropuertos = new Command(BuscarAeropuertos);
            CommandGuardarHistorial = new Command(GuardarHistorial);
            Areopuertos = new List<AreopuertoYC>();
        }

        public void BuscarAeropuertos()
        {
            if (!string.IsNullOrWhiteSpace(TerminoBusqueda))
            {
                try
                {
                    var resultados = _repositorio.BuscarAreopuertos(TerminoBusqueda);

                    if (resultados != null && resultados.Any())
                    {
                        Areopuertos = resultados;
                        var aeropuerto = resultados.First();
                        Resultado = $"Aeropuerto encontrado: {aeropuerto.Name} ({aeropuerto.City}).";
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

        public void GuardarHistorial()
        {
            if (Areopuertos != null && Areopuertos.Any())
            {
                try
                {
                    var historial = Areopuertos.Select(a => new HistorialYC
                    {
                        Name = a.Name,
                        City = a.City,
                        Country = a.Country,
                    }).ToList();

                    _repositorio.GuardarAeropuertos(historial);
                    Resultado = "Aeropuertos guardados en el historial.";
                }
                catch (Exception ex)
                {
                    Resultado = $"Error al guardar en el historial: {ex.Message}";
                }
            }
            else
            {
                Resultado = "No hay aeropuertos para guardar en el historial.";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
