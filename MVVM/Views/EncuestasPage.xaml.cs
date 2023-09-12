using BRMobile.Models;
using BRMobile.ViewModels;

namespace BRMobile.Views
{
    public partial class EncuestasPage : ContentPage
    {
        public EncuestasPage(EncuestasViewModel encuestasViewModel)
        {
            InitializeComponent();
            BindingContext = encuestasViewModel;
        }
    }
}