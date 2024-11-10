namespace UD2EJER5Azael;

[QueryProperty(nameof(NombreCurso), "nombreCurso")]
[QueryProperty(nameof(PrecioCurso), "precioCurso")]
[QueryProperty(nameof(FormaPago), "formaPago")]
public partial class DatosMatricula : ContentPage
{
    private string _nombreCurso;
    private string _precioCurso;
    private string _formaPago;

    public string NombreCurso
    {
        get => _nombreCurso;
        set
        {
            _nombreCurso = value;
            OnPropertyChanged();
            lblCurso.Text = $"curso: {NombreCurso}";
            VerificarBotonCalcular();
        }
    }

    public string PrecioCurso
    {
        get => _precioCurso;
        set
        {
            _precioCurso = value;
            OnPropertyChanged();
            lblPrecio.Text = $"precio inicial: {PrecioCurso}";
            VerificarBotonCalcular();
        }
    }

    public string FormaPago
    {
        get => _formaPago;
        set
        {
            _formaPago = value;
            OnPropertyChanged();
            lblFormaPago.Text = $"metodo de pago: {FormaPago}";
            VerificarBotonCalcular();
        }
    }

    public DatosMatricula()
    {
        InitializeComponent();
        BindingContext = this;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Actualiza el estado de los Labels al aparecer la página
        lblCurso.Text = $"curso: {NombreCurso}";
        lblPrecio.Text = $"precio inicial: {PrecioCurso}";
        lblFormaPago.Text = $"metodo de pago: {FormaPago}";

        // Verifica el estado del botón Calcular
        VerificarBotonCalcular();
    }

    private async void OnSeleccionarCursoClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"Curso?nombreCurso={NombreCurso}&precioCurso={PrecioCurso}&formaPago={FormaPago}");
    }

    private async void OnSeleccionarFormaPagoClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"FormaPago?nombreCurso={NombreCurso}&precioCurso={PrecioCurso}&formaPago={FormaPago}");
    }

    private void VerificarBotonCalcular()
    {
        // Habilita el botón solo si los tres Labels tienen información
        btnCalcularPrecio.IsEnabled = !string.IsNullOrEmpty(NombreCurso) &&
                                       !string.IsNullOrEmpty(PrecioCurso) &&
                                       !string.IsNullOrEmpty(FormaPago);
    }

    private void OnCalcularPrecioClicked(object sender, EventArgs e)
    {
        if (double.TryParse(PrecioCurso.Replace("€", "").Trim(), out double precioInicial))
        {
            double precioFinal = FormaPago == "Con tarjeta" ? precioInicial * 0.9 : precioInicial;
            lblPrecioFinal.Text = $"Precio final: {precioFinal:N2} €"; // Formato de moneda en euros
        }
        else
        {
            lblPrecioFinal.Text = "Error al calcular el precio.";
        }
    }
}
