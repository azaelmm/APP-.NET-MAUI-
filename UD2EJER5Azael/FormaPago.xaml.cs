namespace UD2EJER5Azael;

[QueryProperty(nameof(NombreCurso), "nombreCurso")]
[QueryProperty(nameof(PrecioCurso), "precioCurso")]
public partial class FormaPago : ContentPage
{
    public string NombreCurso { get; set; }
    public string PrecioCurso { get; set; }

    public FormaPago()
    {
        InitializeComponent();
    }

    private async void OnPagoEfectivoClicked(object sender, EventArgs e)
    {
        // Reenv�a los datos que ya se encuentran en las propiedades de la p�gina
        await Shell.Current.GoToAsync($"..?nombreCurso={Uri.EscapeDataString(NombreCurso)}&precioCurso={Uri.EscapeDataString(PrecioCurso)}&formaPago=Al contado");
    }

    private async void OnPagoTarjetaClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"..?nombreCurso={Uri.EscapeDataString(NombreCurso)}&precioCurso={Uri.EscapeDataString(PrecioCurso)}&formaPago=Con tarjeta");
    }
}
