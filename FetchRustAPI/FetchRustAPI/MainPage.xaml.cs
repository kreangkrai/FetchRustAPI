using FetchRustAPI.Models;
using FetchRustAPI.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;

namespace FetchRustAPI
{
    public partial class MainPage : ContentPage
    {
        private static System.Timers.Timer aTimer = new Timer (1000);
        private MainView mv;
        public MainPage()
        {
            InitializeComponent();
            mv = new MainView();
            this.BindingContext = mv;

            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                aTimer.Elapsed += OnTimedEvent;
                aTimer.AutoReset = true;
                aTimer.Enabled = true;
                return false;
            });
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            mv.fetch_data();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            mv.fetch_data();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            mv.fetch_data();
            aTimer.Start();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            aTimer.Stop();
        }
    }
}
