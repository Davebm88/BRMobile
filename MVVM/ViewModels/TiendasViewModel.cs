using BRMobile.Models;
using BRMobile.Repository;
using BRMobile.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ManagerJR.Shared.BRANTANO;
using MvvmHelpers;

namespace BRMobile.ViewModels
{
    public partial class TiendasViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        public static List<Tienda> SearchTiendas { get; set; } = new();

        public ObservableRangeCollection<Tienda> Tiendas { get; set; } = new();

        readonly IRepository _repository;

        [ObservableProperty]
        bool _isBusy;

        public TiendasViewModel(IRepository repository)
        {
            _repository = repository;
            GetTiendasAsync();
        }

        public async void GetTiendasAsync()
        {
            try
            {
                IsBusy = true;
                var responseHttp = await _repository.Get<List<TiendaCAP>>(string.Format(Constants.RestUrl, "tiendas"));
                if (responseHttp.Error)
                {
                    var message = await responseHttp.GetErrorMessageAsync();
                    await App.Current.MainPage.DisplayAlert("Error", message, "Aceptar");
                    SearchTiendas = new List<Tienda>();
                    Tiendas = new ObservableRangeCollection<Tienda>();
                    IsBusy = false;
                    return;
                }

                if (Tiendas.Count > 0)
                    Tiendas.Clear();

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
                    Tiendas.AddRange(list);
                SearchTiendas.AddRange(list);
                IsBusy = false;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.ToString(), "Aceptar");
                SearchTiendas = new List<Tienda>();
                Tiendas = new ObservableRangeCollection<Tienda>();
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task Details(Tienda tienda)
        {
            if (tienda is null)
                return;

            var navigationParameter = new Dictionary<string, object>()
                {
                    {"Tienda", tienda }
                };
            await Shell.Current.GoToAsync($"encuestasdetalle", navigationParameter);
        }
    }
}
