using WpfImageCarousel.Properties;

namespace WpfImageCarousel;

internal class Starter
{
    [STAThread]
    public static void Main(string[] args)
    {
        new App()
            .AddInversionModule<HelperModules>()
            .AddWridDataContext<WireDataContext>()
            .Run();
    }
}
