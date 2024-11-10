namespace UD2EJER5Azael;

public partial class Curso : ContentPage
{
    public Curso()
    {
        InitializeComponent();
    }

    private async void OnCurso1Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"..?nombreCurso=Curso 1&precioCurso=100");
    }

    private async void OnCurso2Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"..?nombreCurso=Curso 2&precioCurso=150");
    }
}
