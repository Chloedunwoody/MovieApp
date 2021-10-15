using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieListPage : ContentPage
    {
        public MovieListPage()
        {
            InitializeComponent();
            
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var movie = ((ListView)sender).SelectedItem as Movie;
            if (movie == null)
                return;
            await DisplayAlert("Movie Selected:", movie.Title, "OK");

        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            //items selected alreaady handled

        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var movie = ((MenuItem)sender).BindingContext as Movie;
            //allows for access to item in list
            if (movie == null)
                return;
            await DisplayAlert("Movie Favorited:", movie.Title, "OK");
        }
    }
}