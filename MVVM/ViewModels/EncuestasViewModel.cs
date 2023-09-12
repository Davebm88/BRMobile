using BRMobile.Models;
using BRMobile.Repository;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ManagerJR.Shared.BRANTANO;
using MvvmHelpers;

namespace BRMobile.ViewModels
{
    public partial class EncuestasViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        public static List<Tienda> SearchTiendas { get; set; } = new();
        public ObservableRangeCollection<Encuesta> Encuestas { get; set; } = new();

        readonly IRepository _repository;

        [ObservableProperty]
        bool _isBusy;

        public EncuestasViewModel(IRepository repository)
        {
            _repository = repository;

            GetTiendasAsync();
            GetEncuestasRecientesAsync();
        }

        public async void GetTiendasAsync()
        {
            try
            {
                var responseHttp = await _repository.Get<List<TiendaCAP>>(string.Format(Constants.RestUrl, "tiendas"));
                if (responseHttp.Error)
                {
                    var message = await responseHttp.GetErrorMessageAsync();
                    await App.Current.MainPage.DisplayAlert("Error", message, "Aceptar");
                    SearchTiendas = new List<Tienda>();
                    return;
                }

                if (SearchTiendas.Count > 0)
                    SearchTiendas.Clear();

                var list = new List<Tienda>();
                list = responseHttp.Response.Select(r => new Tienda
                {
                    Id = r.Id,
                    Descripcion = r.Descripcion,
                    Ubicacion = r.Ubicacion,
                    ImagenUrl = ""
                }).ToList();

                if (list != null)
                    SearchTiendas.AddRange(list);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.ToString(), "Aceptar");
                SearchTiendas = new List<Tienda>();
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

        public async void GetEncuestasRecientesAsync()
        {
            try
            {
                IsBusy = true;
                var responseHttp = await _repository.Get<List<BrantanoCAP>>(string.Format(Constants.RestUrl, string.Format("encuestasu/{0}", "110039")));
                if (responseHttp.Error)
                {
                    var message = await responseHttp.GetErrorMessageAsync();
                    await App.Current.MainPage.DisplayAlert("Error", message, "Aceptar");
                    Encuestas = new ObservableRangeCollection<Encuesta>();
                    IsBusy = false;
                    return;
                }

                if (Encuestas.Count > 0)
                    Encuestas.Clear();

                var list = new List<Encuesta>();
                list = responseHttp.Response.Select(r => new Encuesta
                {
                    Id = r.Id,
                    IdTienda = r.IdTienda,
                    Tienda = r.CategoriaCap,
                    Localidad = r.DescripcionCap,
                    Fecha = r.FechaCapturaCap,
                    FechaModificacion = r.FechaModificacionCap,
                    Cumplimiento = r.CumplimientoCap,
                    Estatus = r.StatusCap,
                    Usuario = "110039"
                }).Take(5).ToList();

                if (list != null)
                    Encuestas.AddRange(list);

                IsBusy = false;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.ToString(), "Aceptar");
                Encuestas = new ObservableRangeCollection<Encuesta>();
                IsBusy = false;
            }
        }
    }
}
