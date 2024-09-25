using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeViewer.Client.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string greeting;

        [RelayCommand]
        public void GreetUser()
        {
            Greeting = $"Hello, {Username}!";
        }

        public MainPageViewModel()
        {
            Username = "John Doe";
        }
    }
}
