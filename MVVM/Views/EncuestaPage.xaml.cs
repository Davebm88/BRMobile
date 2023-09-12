using BRMobile.Models;
using BRMobile.ViewModels;

namespace BRMobile.Views
{
    [QueryProperty(nameof(Encuesta), "Encuesta")]
    public partial class EncuestaPage : ContentPage
    {
        Encuesta encuesta;
        public Encuesta Encuesta
        {
            get => encuesta;
            set
            {
                encuesta = value;
                OnPropertyChanged();
            }
        }

        public EncuestaPage()
        {
            InitializeComponent();
            BindingContext = this;

            App.Current.MainPage.DisplayAlert("Error", (Encuesta?.IdTienda ?? "Encuesta es null"), "Aceptar");
        }
    }
}