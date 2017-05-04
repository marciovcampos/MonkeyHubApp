using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonkeyHubApp.ViewModels
{
    class MainViewModel: BaseViewModel
    {
        private String _searchTerm;

        public String SearchTerm
        {
            get { return _searchTerm; }
            set {
                if(SetProperty( ref _searchTerm, value))
                {
                    SearchCommand.ChangeCanExecute();
                }                        
            }
        }

        public Command SearchCommand { get; }

        public MainViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand, CanExecuteSearchCommand);
        }

        async void ExecuteSearchCommand()
        {
            await Task.Delay(2000);

            bool resposta = await App.Current.MainPage.DisplayAlert("MonkeyHubApp", $"Você pesquisou por '{SearchTerm}'.","Sim", "Não");

            if (resposta)
            {
                await App.Current.MainPage.DisplayAlert("MonkeyHubApp", $"Obrigado", "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("MonkeyHubApp", $"Que pena!", "OK");
            }

        }
        
        bool CanExecuteSearchCommand()
        {
            return string.IsNullOrWhiteSpace(SearchTerm) == false;
        }

    }
}
