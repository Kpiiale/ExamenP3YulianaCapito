using ExamenP3YulianaCapito.Models;
using ExamenP3YulianaCapito.Repositories;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ExamenP3YulianaCapito.ViewModels
{
    public class HistorialViewModel : INotifyPropertyChanged
    {
        private readonly AeropuertoSQLiteRepository _repositorioSQLite;

        private ObservableCollection<HistorialYC> _historial;

        public ObservableCollection<HistorialYC> Historial
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

        public ICommand CargarHistorialCommand { get; set; }

        public HistorialViewModel()
        {
            _repositorioSQLite = new AeropuertoSQLiteRepository();
            _historial = new ObservableCollection<HistorialYC>();
            CargarHistorialCommand = new Command(CargarHistorial);
            CargarHistorial();
        }

        private void CargarHistorial()
        {
            var historialGuardado = _repositorioSQLite.ObtenerAeropuertosGuardados();
            Historial = new ObservableCollection<HistorialYC>(historialGuardado);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
