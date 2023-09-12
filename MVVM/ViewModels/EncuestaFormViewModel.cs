using BRMobile.Models;
using BRMobile.Repository;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BRMobile.ViewModels
{
    [QueryProperty(nameof(Encuesta), "Encuesta")]
    public partial class EncuestaFormViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
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
        readonly IRepository _repository;

        public EncuestaFormViewModel(IRepository repository)
        {
            _repository = repository;

            App.Current.MainPage.DisplayAlert("Error", (encuesta?.IdTienda ?? "Encuesta es null"), "Aceptar");
        }
    }
}
