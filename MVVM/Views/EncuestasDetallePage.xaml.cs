using BRMobile.Models;
using BRMobile.ViewModels;

namespace BRMobile.Views
{
    public partial class EncuestasDetallePage : ContentPage
    {
        public EncuestasDetallePage(EncuestasDetalleViewModel encuestasDetViewModel)
        {
            InitializeComponent();
            BindingContext = encuestasDetViewModel;
        }
    }
}