using IMCMVVM_JARV.ViewModels;

namespace IMCMVVM_JARV
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new IMCViewModel();
        }
    }
}