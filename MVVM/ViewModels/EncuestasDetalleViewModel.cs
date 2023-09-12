using BRMobile.Models;
using BRMobile.Repository;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ManagerJR.Shared.BRANTANO;
using Microsoft.Maui.Controls.Xaml;
using MvvmHelpers;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BRMobile.ViewModels
{
    [QueryProperty(nameof(Tienda), "Tienda")]
    public partial class EncuestasDetalleViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        [ObservableProperty]
        public Tienda tienda;

        public ObservableRangeCollection<Encuesta> Encuestas { get; set; } = new();

        readonly IRepository _repository;

        public EncuestasDetalleViewModel(IRepository repository)
        {
            _repository = repository;

            GetEncuestasRecientesAsync();
        }

        public async void GetEncuestasRecientesAsync()
        {
            try
            {
                await App.Current.MainPage.DisplayAlert("Datos", ("Tienda: " + Tienda.Id + "\nNombre: " + Tienda.Descripcion + "\nUbicacion: " + Tienda.Ubicacion), "Aceptar");

                //var responseHttp = await _repository.Get<List<BrantanoCAP>>(string.Format(Constants.RestUrl, string.Format("encuestast/{0}", Tienda.Id)));
                //if (responseHttp.Error)
                //{
                //    var message = await responseHttp.GetErrorMessageAsync();
                //    await App.Current.MainPage.DisplayAlert("Error", message, "Aceptar");
                //    Encuestas = new ObservableRangeCollection<Encuesta>();
                //    return;
                //}

                //if (Encuestas.Count > 0)
                //    Encuestas.Clear();

                //var list = new List<Encuesta>();
                //list = responseHttp.Response.Select(r => new Encuesta
                //{
                //    Id = r.Id,
                //    IdTienda = r.IdTienda,
                //    Tienda = r.CategoriaCap,
                //    Localidad = r.DescripcionCap,
                //    Fecha = r.FechaCapturaCap,
                //    FechaModificacion = r.FechaModificacionCap,
                //    Cumplimiento = r.CumplimientoCap,
                //    Estatus = r.StatusCap,
                //    Usuario = r.UsuarioCap
                //}).Take(5).ToList();

                //if (list != null)
                //    Encuestas.AddRange(list);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.ToString(), "Aceptar");
                Encuestas = new ObservableRangeCollection<Encuesta>();
            }
        }

        [RelayCommand]
        public async Task Details(Encuesta encuesta)
        {
            if (encuesta is null)
                return;

            var navigationParameter = new Dictionary<string, object>()
            {
                {"Encuesta", encuesta }
            };
            await Shell.Current.GoToAsync($"encuesta", navigationParameter);
        }
    }
}
