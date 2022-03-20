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
            Authors = GetMenus();
        }
        public ObservableCollection<Author> Authors { get; set; }
        private ObservableCollection<Author> GetMenus()
        {
            return new ObservableCollection<Author>
            {
                new Author {img = "add.png"},
                new Author {img = "add.png"},
                new Author {img = "add.png"}
            };
        }
    }
    public class Author
    {
        public string img { get; set; }
    }
}