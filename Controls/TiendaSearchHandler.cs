using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRMobile.Models;

namespace BRMobile.Controls
{
    public class TiendaSearchHandler : SearchHandler
    {
        public IList<Tienda> Tiendas { get; set; }
        public Type SelectedItemNavigationTarget { get; set; }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if(string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else 
            {
                ItemsSource = Tiendas
                    .Where(t => t.Descripcion.ToLower().Contains(newValue.ToLower()))
                    .ToList<Tienda>();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);

            Tienda tienda = item as Tienda;
            string navigationTarget = GetNavigationTarget();

            //if (navigationTarget != null)
            //{
            //    var navigationParameters = new Dictionary<string, object>
            //    {
            //        { "SelectedTienda", tienda }
            //    };

            //    await Shell.Current.GoToAsync($"{navigationTarget}", navigationParameters);
            //}
            var navigationParameters = new Dictionary<string, object>
            {
                { "Tienda", tienda }
            };

            await Shell.Current.GoToAsync($"encuestasdetalle", navigationParameters);
        }

        string GetNavigationTarget()
        {
            return (Shell.Current as AppShell).Routes.FirstOrDefault(route => route.Value.Equals(SelectedItemNavigationTarget)).Key;
        }
    }
}
