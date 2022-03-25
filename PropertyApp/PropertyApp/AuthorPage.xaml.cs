using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PropertyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorPage : ContentPage
    {
        public AuthorPage()
        {
            InitializeComponent();  
        }
        private void imgAuthor(object sender, EventArgs e)
        {
            DisplayAlert("Author", "K+ RAVIL \nADLER BACKEND \nKISLOTNY", "Ok");
        }
        private async void imgInfoPlan(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }



    }
}