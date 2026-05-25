using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace apphotell.Models
{
    public partial class ReservaModel : INotifyPropertyChanged
    {
        private string _nomeHospede = "";
        private int _numeroQuartos = 1;
        private DateTime _dataCheckin = DateTime.Today;
        private DateTime _dataCheckout = DateTime.Today.AddDays(1);
        private string _tipoQuarto = "";

        public string NomeHospede
        {
            get => _nomeHospede;
            set { _nomeHospede = value; OnPropertyChanged(); }
        }

        public int NumeroQuartos
        {
            get => _numeroQuartos;
            set { _numeroQuartos = value; OnPropertyChanged(); }
        }

        public DateTime DataCheckin
        {
            get => _dataCheckin;
            set { _dataCheckin = value; OnPropertyChanged(); }
        }

        public DateTime DataCheckout
        {
            get => _dataCheckout;
            set { _dataCheckout = value; OnPropertyChanged(); }
        }

        public string TipoQuarto
        {
            get => _tipoQuarto;
            set { _tipoQuarto = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}