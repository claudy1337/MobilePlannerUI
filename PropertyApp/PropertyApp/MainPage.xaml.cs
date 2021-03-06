using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Data;
using System.Timers;


namespace PropertyApp
{
   
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MenuItems = GetMenus();
            this.BindingContext = this;
        }

        public List<PropertyType> PropertyTypeList => GetPropertyTypes();
        public List<Property> PropertyList => GetProperties();

        private List<PropertyType> GetPropertyTypes()
        {
            return new List<PropertyType>
            {
                new PropertyType { TypeName = "Value 1" },
                new PropertyType { TypeName = "Value 2" },
                new PropertyType { TypeName = "Value 3" },
                new PropertyType { TypeName = "Value 4" }
            };
        }
        DateTime someDate = new DateTime(2022, 3, 18);
        private List<Property> GetProperties()
        {
            return new List<Property>
            {
                new Property { Image = "backroundList.png", Name = "Aboba" , Actualling = "No Actual", Date = someDate, Bed = "detailed",   Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },
                new Property { Image = "BackroundPain.png", Name = "Birth Day" , Actualling = "Actual", Date = someDate, Bed = "detailed",   Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },
                new Property { Image = "backroundPole.png", Name = "Cringe Malibu" , Actualling = "Actual", Date = someDate, Bed = "detailed",   Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },
                new Property { Image = "BackroundRain.png", Name = "Ukraine Sabatage" , Actualling = "No Actual", Date = someDate, Bed = "detailed",   Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },
                new Property { Image = "backroundWood.png", Name = "Aboba" , Actualling = "Actual", Date = someDate, Bed = "detailed",   Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },
                new Property { Image = "BackroundWater.png", Name = "Aboba" , Actualling = "Actual", Date = someDate, Bed = "detailed",   Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" }
                
            };
        }

        private async void PropertySelected(object sender, EventArgs e)
        {
            var property = (sender as View).BindingContext as Property;
            await this.Navigation.PushAsync(new DetailsPage(property));
        }

        private void SelectType(object sender, EventArgs e)
        {
            var view = sender as View;
            var parent = view.Parent as StackLayout;

            foreach(var child in parent.Children)
            {
                VisualStateManager.GoToState(child, "Normal");
                ChangeTextColor(child, "#707070");
            }

            VisualStateManager.GoToState(view, "Selected");
            ChangeTextColor(view, "#FFFFFF");
        }

        private void ChangeTextColor(View child, string hexColor)
        {
            var txtCtrl = child.FindByName<Label>("PropertyTypeName");

            if (txtCtrl != null)
                txtCtrl.TextColor = Color.FromHex(hexColor);
        }

        public ObservableCollection<Menu> MenuItems { get; set; }


        private ObservableCollection<Menu> GetMenus()
        {
            return new ObservableCollection<Menu>
            {
                new Menu { Title = "THEME", imgMenu = "file.png"},
                new Menu { Title = "NEW", imgMenu = "create.png" },
                new Menu { Title = "TIME" , imgMenu = "time.png"},
                new Menu { Title = "AUTHOR", imgMenu = "group.png"}
            };
        }

        private async void Show()
        {
            _ = TitleTxt.FadeTo(0);
            _ = MenuItemsView.FadeTo(1);
            await MainMenuView.RotateTo(0, 300, Easing.BounceOut);
        }

        private async void Hide()
        {
            _ = TitleTxt.FadeTo(1);
            _ = MenuItemsView.FadeTo(0);
            await MainMenuView.RotateTo(-90, 300, Easing.BounceOut);
        }

        private void ShowMenu(object sender, EventArgs e)
        {
            Show();
        }

        private async void MenuTapped(object sender, EventArgs e)
        {
            TitleTxt.Text = ((sender as StackLayout).BindingContext as Menu).Title;
            Hide();
            if (TitleTxt.Text == "NEW")
            {
                await Navigation.PushAsync(new CreatePlan());
            }
            else if (TitleTxt.Text == "AUTHOR")
            {
                await Navigation.PushAsync(new AuthorPage());
            }
            else if (TitleTxt.Text == "TIME")
            {
                await Navigation.PushAsync(new TimePage());
            }
            else if(TitleTxt.Text == "THEME")
            {
                await Navigation.PushAsync(new Theme());
            }
        }

        private async void UpdateView_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            UpdateView.IsRefreshing = false;
            
        }
    }

    public class PropertyType
    {
        public string TypeName { get; set; }
    
    }
    public class Menu
    {
        public string Title { get; set; }
        public string imgMenu { get; set; }


    }

    public class Property
    {
        public string Id => Guid.NewGuid().ToString("N");
        public string PropertyName { get; set; }
        public string Image { get; set; }
        public string Actualling { get; set; }
        public DateTime Date { get; set; }
        public string Bed { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
    }
}
