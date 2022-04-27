using FetchRustAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FetchRustAPI.ViewModel
{
    class MainView : INotifyPropertyChanged
    {
        private ObservableCollection<datasModel> _datas;
        public ObservableCollection<datasModel> Datas
        {
            get
            {              
                return this._datas;
            }
            set
            {
                this._datas = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public MainView()
        {          
            Datas = new ObservableCollection<datasModel>();
        }

        public async void fetch_data()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("http://172.20.10.8:8082/datas");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            Datas = JsonConvert.DeserializeObject<ObservableCollection<datasModel>>(responseBody);        
        }
    }
    
}
