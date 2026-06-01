using apphotell.Models;

namespace apphotell.Views;

public partial class CadastroEvento : ContentPage
{
    public CadastroEvento()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Evento evento = new Evento
            {
                NomeEvento = txt_nome.Text,
                DataInicio = dtpck_inicio.Date.GetValueOrDefault(DateTime.Today),
                DataTermino = dtpck_termino.Date.GetValueOrDefault(DateTime.Today),
                NumeroParticipantes = Convert.ToInt32(txt_participantes.Text),
                LocalEvento = txt_local.Text,
                CustoPorParticipante = Convert.ToDouble(txt_custo.Text)
            };

            if (evento.DataTermino < evento.DataInicio)
            {
                await DisplayAlert("Erro", "A data de término não pode ser menor que a data de início.", "OK");
                return;
            }

            await Navigation.PushAsync(new ResumoEvento()
            {
                BindingContext = evento
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}