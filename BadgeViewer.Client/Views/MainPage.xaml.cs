using BadgeViewer.Client.ViewModels;

namespace BadgeViewer.Client.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnHandlerChanged()
        {
            base.OnHandlerChanged();

            BindingContext = Handler?.MauiContext?.Services?.GetService<MainPageViewModel>();
        }
    }

}
