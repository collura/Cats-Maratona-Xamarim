using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Cats
{
    public class CatsViewModel : INotifyPropertyChanged
    {

        //Implements de resource that will notify view about changes
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName]
        string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        //Varible for avoid duplicate changes
        private bool busy;
        public Command GetCatsCommand { get; set; }

        public bool IsBusy {
            get { return busy; }
            set { this.busy = value;
                OnPropertyChanged();
                //Forces to looks again the Command Function if is active or not
                GetCatsCommand.ChangeCanExecute();
            }
        }
            

        //Collection that avoid has to use Propertychanged() in each changing in collection.
        public ObservableCollection<Cat> Cats { get; set; }


        public CatsViewModel() {
            //Begin the list
            Cats = new ObservableCollection<Cat>();
            GetCatsCommand = new Command (async () => await getCats(), () => !IsBusy);
        }


        //Method to return The Cats List from Repository
        async Task getCats() {
            if (!IsBusy) {
                Exception error = null;
                try
                {
                    IsBusy = true;
                    var Repository = new Repository();
                    var Items = await Repository.GetCats();
                    Cats.Clear();
                    foreach (var Item in Items) {
                        Cats.Add(Item);
                    }    
                }
                catch(Exception ex)
                {
                    error = ex;
                }
                finally {
                    IsBusy = false;

                    if (error != null) {
                        await Application.Current.MainPage.DisplayAlert("Error !", error.Message, "Cancelar");
                    }
                }

            } 
        }
    }
}    
