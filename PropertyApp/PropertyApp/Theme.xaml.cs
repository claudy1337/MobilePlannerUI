﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PropertyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Theme : ContentPage
    {
        public Theme()
        {
            InitializeComponent();
            
        }
        private void GoBack(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}