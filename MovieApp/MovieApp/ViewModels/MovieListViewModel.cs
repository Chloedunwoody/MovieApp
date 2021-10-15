using MovieApp.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MovieApp.ViewModels
{
  
    public class MovieListViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Movie> MovieList { get; set; }

        public ObservableRangeCollection<Grouping<string, Movie>> MovieGroup { get; set; }

        //when something takes a long time  use async command, dont block ui threa,  because for user it seems frozen...
        public AsyncCommand RefreshCommand { get; }


        public MovieListViewModel()
        {
            Title = "Movie List";

            MovieList = new ObservableRangeCollection<Movie>();

            MovieGroup = new ObservableRangeCollection<Grouping<string, Movie>>();
            RefreshCommand = new AsyncCommand(Refresh);


            MovieList.Add(new Movie
            {
                Title = "Crimson Tide",
                Image = "https://resizing.flixster.com/8S81Qtb5ljaebFsCiGyYxHmgsg8=/206x305/v2/https://flxt.tmsimg.com/assets/p16733_p_v8_aj.jpg",
                Genre = "Drama"
            }
                    );
            MovieList.Add(new Movie
            {
                Title = "Frozen River",
                Image = "https://resizing.flixster.com/z-K09WlHLImxkA4wvoRsIKYLV84=/206x305/v2/https://flxt.tmsimg.com/assets/p179131_p_v10_aa.jpg",
                Genre = "Drama"
            }
                );
            MovieList.Add(new Movie
            {
                Title = "The Abyss",
                Image = "https://resizing.flixster.com/enQ7oxYRhE-6PE2AITzJoiQmueI=/206x305/v2/https://flxt.tmsimg.com/assets/p11774_p_v10_ae.jpg",
                Genre = "Sci-fi"
            }
                );
            MovieList.Add(new Movie
            {
                Title = "True Crimes",
                Image = "https://resizing.flixster.com/hbNSQ1jcA_yOxViH9Dr3UriXT3E=/206x305/v2/https://flxt.tmsimg.com/assets/p179467_p_v10_ab.jpg",
                Genre = "Action"
            }
                );
            MovieList.Add(new Movie
            {
                Title = "Sunshine Cleaning",
                Image = "https://resizing.flixster.com/yYwkBpSninXDblKYNm8sRG1r4oE=/206x305/v2/https://flxt.tmsimg.com/assets/p183429_p_v10_ae.jpg",
                Genre = "Comedy"
            }
                );
            MovieList.Add(new Movie
            {
                Title = "Obeserve",
                Image = "https://resizing.flixster.com/EfW4zmCLqWKlSBNZyQCqoneTKaY=/206x305/v2/https://flxt.tmsimg.com/assets/p190670_p_v10_ag.jpg",
                Genre = "Comedy"
            }
                );
            MovieList.Add(new Movie
            {
                Title = "Movie 7",
                Image = "https://www.imdb.com/title/tt7657566/mediaviewer/rm2503385601/?ref_=tt_ov_i",
                Genre = "Fun"
            }
                );
            MovieList.Add(new Movie
            {
                Title = "Machete",
                Image = "https://resizing.flixster.com/zgEx4-rAVJr-TZKZK0KGS3ZrTeU=/206x305/v2/https://flxt.tmsimg.com/assets/p8097568_p_v10_aj.jpg",
                Genre = "Action"
            }
                );

            //MovieGroup.Add(new Grouping<string, Movie>("Comedy", new[] { MovieList[1] }));
            //MovieGroup.Add(new Grouping<string, Movie>("Horror", MovieList.Take(1)));
            MovieGroup.Add(new Grouping<string, Movie>("Action", MovieList.Where(x => x.Genre.Contains("Action"))));
            MovieGroup.Add(new Grouping<string, Movie>("Drama", MovieList.Where(x => x.Genre.Contains("Drama"))));
            MovieGroup.Add(new Grouping<string, Movie>("Comedy", MovieList.Where(x => x.Genre.Contains("Comedy"))));

        }

        //when using await must async type in command def.
        private async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            IsBusy = false;
        }
    }
}
