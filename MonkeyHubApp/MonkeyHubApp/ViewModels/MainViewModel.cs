using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonkeyHubApp.ViewModels
{
    class MainViewModel: BaseViewModel
    {
        private string _searchTerm;

        public string SearchTerm
        {
            get { return _searchTerm; }
            set {
                if(SetProperty( ref _searchTerm, value))
                {
                    SearchCommand.ChangeCanExecute();
                }                        
            }
        }

        public ObservableCollection<string> Resultados { get; }

        public Command SearchCommand { get; }

        public MainViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand, CanExecuteSearchCommand);

            Resultados = new ObservableCollection<string>(new[] { "abc", "cde" });

            //List<string> X = new List<string>();
            //var listaDeItensNovos = new[] { "abc", "cde" };

            //X.AddRange(listaDeItensNovos);

            //foreach(var itemNovo in listaDeItensNovos)
            //{
            //    Resultados.Add(itemNovo);
            //}

            
        }

        async void ExecuteSearchCommand()
        {
            //await Task.Delay(2000);

            bool resposta = await App.Current.MainPage.DisplayAlert("MonkeyHubApp", $"Você pesquisou por '{SearchTerm}'.","Sim", "Não");

            if (resposta)
            {
                await App.Current.MainPage.DisplayAlert("MonkeyHubApp", $"Obrigado", "OK");
                Resultados.Add("Sim");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("MonkeyHubApp", $"Que pena!", "OK");
                Resultados.Add("Não");
            }

        }
        
        bool CanExecuteSearchCommand()
        {
            return string.IsNullOrWhiteSpace(SearchTerm) == false;
        }

    }
}
