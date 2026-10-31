using IMCMVVM_JARV.Views;

namespace IMCMVVM_JARV
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(imcPage), typeof(imcPage));
        }
    }
}