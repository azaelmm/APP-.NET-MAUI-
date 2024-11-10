namespace UD2EJER5Azael
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Curso), typeof(Curso));
            Routing.RegisterRoute(nameof(FormaPago), typeof(FormaPago));
        }
    }
}
