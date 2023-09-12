using BRMobile.ViewModels;
using BRMobile.Views;
using System.Windows.Input;

namespace BRMobile
{
    public partial class AppShell : Shell
    {
        public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();
        public ICommand HelpCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        void RegisterRoutes()
        {
            Routes.Add("encuestasdetalle", typeof(EncuestasDetallePage));
            Routes.Add("encuestas", typeof(EncuestasPage));
            Routes.Add("encuesta", typeof(EncuestaPage));
            foreach (var item in Routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}