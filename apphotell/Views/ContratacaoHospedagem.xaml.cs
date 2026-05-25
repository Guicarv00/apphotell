namespace apphotell.Views;

using System.Linq;

public partial class ContratacaoHospedagem : ContentPage
{
    private int _adultos = 0;
    private int _criancas = 0;
    private int _quartoIndex = -1;

    public ContratacaoHospedagem()
    {
        InitializeComponent();
    }

    private void btn_mais_adulto(object sender, EventArgs e)
    {
        _adultos++;
        lbl_adultos.Text = _adultos.ToString();
    }

    private void btn_menos_adulto(object sender, EventArgs e)
    {
        if (_adultos > 0) _adultos--;
        lbl_adultos.Text = _adultos.ToString();
    }

    private void btn_mais_crianca(object sender, EventArgs e)
    {
        _criancas++;
        lbl_criancas.Text = _criancas.ToString();
    }

    private void btn_menos_crianca(object sender, EventArgs e)
    {
        if (_criancas > 0) _criancas--;
        lbl_criancas.Text = _criancas.ToString();
    }

    private async void OnEscolherQuarto(object sender, EventArgs e)
    {
        var opcoes = App.QuartosDisponiveis.Select(q => q.Descricao).ToArray();
        var resultado = await DisplayActionSheet("Escolha o quarto", "Cancelar", null, opcoes);

        if (resultado != null && resultado != "Cancelar")
        {
            lbl_quarto_selecionado.Text = resultado;
            lbl_quarto_selecionado.TextColor = Colors.White;
            _quartoIndex = App.QuartosDisponiveis.FindIndex(q => q.Descricao == resultado);
        }
    }

    private void dp_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DateTime data = e.NewDate.Value;
        dp_checkout.MinimumDate = data.AddDays(1);
        dp_checkout.MaximumDate = data.AddMonths(6);
    }

    private async void btn_calcular_Clicked(object sender, EventArgs e)
    {
        if (_quartoIndex == -1)
        {
            await DisplayAlert("Atenção", "Selecione um quarto!", "OK");
            return;
        }

        if (_adultos == 0)
        {
            await DisplayAlert("Atenção", "Informe pelo menos 1 adulto!", "OK");
            return;
        }

        if (dp_checkout.Date <= dp_checkin.Date)
        {
            await DisplayAlert("Atenção", "Check-out deve ser após o Check-in!", "OK");
            return;
        }

        var quarto = App.QuartosDisponiveis[_quartoIndex];
        int dias = (dp_checkout.Date.Value - dp_checkin.Date.Value).Days;
        double totalAdultos = quarto.ValorDiariaAdulto * _adultos * dias;
        double totalCriancas = quarto.ValorDiariaCrianca * _criancas * dias;
        double total = totalAdultos + totalCriancas;

        await DisplayAlert("💰 Total da Reserva",
            $"Quarto: {quarto.Descricao}\n" +
            $"Adultos: {_adultos} x R$ {quarto.ValorDiariaAdulto:F2} x {dias} dias\n" +
            $"Crianças: {_criancas} x R$ {quarto.ValorDiariaCrianca:F2} x {dias} dias\n" +
            $"────────────────\n" +
            $"Total: R$ {total:F2}",
            "OK");
    }
}