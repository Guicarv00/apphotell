namespace apphotell
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("ContratacaoHospedagem", typeof(Views.ContratacaoHospedagem));
        }
    }
}