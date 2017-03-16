using Cats.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cats
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatsPage : ContentPage
    {
        public CatsPage()
        {
            InitializeComponent();
            ListViewCats.ItemSelected += ListViewCats_ItemSelected;
        }


        private async void ListViewCats_ItemSelected(Object sender, SelectedItemChangedEventArgs e)
        {
            var SelectedCat = e.SelectedItem as Cat;

            if (SelectedCat != null) {
                await Navigation.PushAsync(new DetailsPage(SelectedCat));
                ListViewCats.SelectedItem = null;
            }          
        }
    }
}
