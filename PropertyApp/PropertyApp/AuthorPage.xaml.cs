﻿using System;
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
        private void GoBack(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

    }
}