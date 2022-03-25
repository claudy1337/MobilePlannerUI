using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PropertyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(Property property)
        {
            InitializeComponent();
            this.Property = property;
            this.BindingContext = this;
        }

        public Property Property { get; set; }

        private void GoBack(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DetailsView.TranslationY = 600;
            DetailsView.TranslateTo(0, 0, 500, Easing.SinInOut);
        }

        private async void ImgAddPlann(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreatePlan());
        }
      
        private async void imgEditPlan(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditPlan());
        }
        private void imgMorePlan(object sender, EventArgs e)
        {
            DisplayAlert("More", $"{"Name: " + Property.Name + "\nDate:" + Property.Date}" , "Close");
            
        }
        private void imgNotificationPlan(object sender, EventArgs e)
        {
            
            DisplayAlert("New Notification", "ZZ ONE LOVE", "Close");
        }
        private async void imgDeletePlan(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Delete", $"Delete in {Property.Name}", "Yep", "Nope");
            await DisplayAlert("Notification", "Result: " + (result ? "Deleted" : "Removal"), "OK");
        }
    }
}