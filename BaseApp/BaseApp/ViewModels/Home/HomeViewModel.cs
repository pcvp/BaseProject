using BaseApp.Helpers;
using BaseApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace BaseApp.ViewModels.Home {

    public class HomeViewModel : BaseViewModel {

        public HomeViewModel() {
            Carregar();
        }

        public void Carregar() {
            
        }



        public Command RefreshCommand => new Command(() => {
            Carregar();
        });



        public bool IsRefreshing { get; set; }
    }
}