using apphotell.Models;

namespace apphotell
{   
    public partial class App : Application
    {

        public static List<Quarto> QuartosDisponiveis = new()
        {

        new Quarto()
           {
                Descricao = "Suíte Premium",
                ValorDiariaAdulto = 120.0,
                ValorDiariaCrianca = 65.0

            },
            new Quarto()
            {

                Descricao = "Suíte Luxo",
                ValorDiariaAdulto = 50.0,
                ValorDiariaCrianca = 32.0
            },
            new Quarto()
            {
                Descricao = "Suíte Simples",
                ValorDiariaAdulto = 25.0,
                ValorDiariaCrianca = 16.0
            }

        };

        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}