using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EventTracker
{
   
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MyEvents = GetEvents();
            this.BindingContext = this;
        }

        public ObservableCollection<Event> MyEvents { get; set; }

        private ObservableCollection<Event> GetEvents()
        {
            return new ObservableCollection<Event>
            {
                
                new Event { Title = "Name Planner", Image = "win.png", Venue = "TitlePlanner", Duration = "07:30 UTC - 09:30 UTC", Date = new DateTime(2020, 6, 10), Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy"},
                new Event { Title = "Name Planner", Image = "win.png", Venue = "Title Planner", Duration = "07:30 UTC - 09:30 UTC", Date = new DateTime(2020, 6, 11), Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy"},
                new Event { Title = "Name Planner", Image = "win.png", Venue = "Title Planner", Duration = "07:30 UTC - 09:30 UTC", Date = new DateTime(2020, 6, 12), Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy"}
            };
        }

        private async Task OpenAnimation(View view, uint length = 250)
        {
            view.RotationX = -90;
            view.IsVisible = true;
            view.Opacity = 0;
            _ = view.FadeTo(1, length);
            await view.RotateXTo(0, length);
        }

        private async Task CloseAnimation(View view, uint length = 250)
        {
            _ = view.FadeTo(0, length);
            await view.RotateXTo(-90, length);
            view.IsVisible = false;
        }

        private async void MainExpander_Tapped(object sender, EventArgs e)
        {
            var expander = sender as Expander;
            var imgView = expander.FindByName<Grid>("ImageView");
            var detailsView = expander.FindByName<Grid>("DetailsView");

            if (expander.IsExpanded)
            {
                await OpenAnimation(imgView);
                await OpenAnimation(detailsView);
            }
            else
            {
                await CloseAnimation(detailsView);
                await CloseAnimation(imgView);
            }
        }
    }

    public class Event
    {
        public string Title { get; set; }
        public string Venue { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
    }
    
}
