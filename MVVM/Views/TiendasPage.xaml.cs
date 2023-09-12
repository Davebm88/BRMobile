using BRMobile.Models;
using BRMobile.ViewModels;

namespace BRMobile.Views
{
    public partial class TiendasPage : ContentPage
    {
        public TiendasPage(TiendasViewModel tiendasViewModel)
        {
            InitializeComponent();
            BindingContext = tiendasViewModel;
        }
    }
}