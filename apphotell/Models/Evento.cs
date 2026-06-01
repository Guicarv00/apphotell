namespace apphotell.Models
{
    public class Evento
    {
        public string NomeEvento { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public int NumeroParticipantes { get; set; }
        public string LocalEvento { get; set; } = string.Empty;
        public double CustoPorParticipante { get; set; }

        public TimeSpan Duracao
        {
            get => DataTermino.Subtract(DataInicio);
        }

        public int DuracaoEmDias
        {
            get => Duracao.Days;
        }

        public double CustoTotal
        {
            get
            {
                double total = NumeroParticipantes * CustoPorParticipante;
                return total;
            }
        }
    }
}