using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MonkeyHubApp.ViewModels
{
    class MainViewModel: BaseViewModel
    {        
        private string _descricao;

        public string Descricao
        {
            get { return _descricao; }
            set { SetProperty(ref _descricao, value); }
        }

        public MainViewModel()
        {
            Descricao = "Olá mundo! Eu Estou Aqui!";
            Task.Delay(3000).ContinueWith(async t =>
            {
                for(int i = 0; i<10; i++)
                {
                    await Task.Delay(1000);
                    Descricao = $"Meu Texto Mudou{i}";
                }              
                                 
            });
        }   

        

       

    }
}
