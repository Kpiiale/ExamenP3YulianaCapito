using ExamenP3YulianaCapito.Interfaces;
using ExamenP3YulianaCapito.Models;
using ExamenP3YulianaCapito.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
            _repositorio = new AreopuertoRepository();  
            CommandBuscarAeropuertos = new Command(BuscarAeropuertos); 
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
                        Resultado = $"Se encontraron {resultados.Count} aeropuertos.";
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

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}