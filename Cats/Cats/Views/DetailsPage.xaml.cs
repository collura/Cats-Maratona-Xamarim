using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cats.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        private Cat SelectCat;

        public DetailsPage(Cat selectedCat)
        {
            InitializeComponent();
            this.SelectCat = selectedCat;
            this.BindingContext = SelectCat;
            ButtonWebSite.Clicked += ButtonWebSite_Clicked;
        }

        //Method to open Browser
        private void ButtonWebSite_Clicked(Object sender, EventArgs e) {
            if (SelectCat.WebSite.StartsWith("http")) {
                Device.OpenUri(new Uri(SelectCat.WebSite));
            }
        }
    }
}
