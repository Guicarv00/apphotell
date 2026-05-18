using apphotell.Models;

namespace apphotell;

public partial class MainPage : ContentPage
{
    private ReservaModel _reserva;

    public MainPage()
    {
        InitializeComponent();
        _reserva = new ReservaModel();
        BindingContext = _reserva;
    }

    private async void OnReservarClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Reservado✅", "Reserva realizada com sucesso!", "OK");
    }

    private async void Sobre_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sobre());
    }
}