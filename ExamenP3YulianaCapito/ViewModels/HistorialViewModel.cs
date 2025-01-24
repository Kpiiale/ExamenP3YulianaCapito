using ExamenP3YulianaCapito.Interfaces;
using ExamenP3YulianaCapito.Models;
using ExamenP3YulianaCapito.Repositories;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExamenP3YulianaCapito.ViewModels
{
    public class HistorialViewModel : INotifyPropertyChanged
    {
        private List<HistorialYC> _historial;
        private IAreopuertoRepository _repositorio;

        public List<HistorialYC> Historial
        {
            get => _historial;
            set
            {
                if (_historial != value)
                {
                    _historial = value;
                    OnPropertyChanged();
                }
            }
        }

        public HistorialViewModel()
        {
            _repositorio = new AeropuertoSQLiteRepository();
            CargarHistorial();
        }

        private void CargarHistorial()
        {
            Historial = _repositorio.ObtenerAeropuertosGuardados();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
