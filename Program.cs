namespace pe.com.communitas.ui;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Categoria.frmCategoria());
    }
}
