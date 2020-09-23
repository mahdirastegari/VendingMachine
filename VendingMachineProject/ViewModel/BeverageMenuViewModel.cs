using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using VendingMachineProject.Messages;
using VendingMachineProject.Model;
using VendingMachineProject.View;

namespace VendingMachineProject.ViewModel
{
    public class BeverageMenuViewModel : ViewModelBase , IView
    {
        private Beverage _selectedBeverage;

      

        // you can fill this data from db
        // we also have some share task for example boil water or add water
        // which we can create only one BeverageTask
        public List<Beverage> Beverages { get; set; } = new List<Beverage>()
        {
            new Beverage("Hot Chocolate" , 
                new BitmapImage(new Uri("/Assets/hot_chocolate.jpg", UriKind.Relative)) , 
                new BeverageTask("Boil water" , TimeSpan.FromSeconds(2)),
                new BeverageTask("Add drinking chocolate to cup" , TimeSpan.FromSeconds(2)),
                new BeverageTask("Add water" , TimeSpan.FromSeconds(2))) ,

            new Beverage("White Coffee" ,
                new BitmapImage(new Uri("/Assets/white_coffee.jpg", UriKind.Relative)) ,
                new BeverageTask("Boil water" , TimeSpan.FromSeconds(2)),
                new BeverageTask("Add sugar" , TimeSpan.FromSeconds(2)),
                new BeverageTask("Add coffee granules to cup" , TimeSpan.FromSeconds(2)),
                new BeverageTask("Add water" , TimeSpan.FromSeconds(2)),
                new BeverageTask("Add milk" , TimeSpan.FromSeconds(2))) ,

            new Beverage("Iced Coffee" ,
                new BitmapImage(new Uri("/Assets/iced_coffee.jpg", UriKind.Relative)) ,
                new BeverageTask("Crush Ice" , TimeSpan.FromSeconds(2)),
                new BeverageTask("Add ice to blender" , TimeSpan.FromSeconds(2)),
                new BeverageTask("Add coffee syrup to blender" , TimeSpan.FromSeconds(2)),
                new BeverageTask("Blend ingredients" , TimeSpan.FromSeconds(2)),
                new BeverageTask("Add ingredients" , TimeSpan.FromSeconds(2))) ,

            new Beverage("Lemon Tea" ,
                new BitmapImage(new Uri("/Assets/lemon_tea.jpg", UriKind.Relative)) ,
                new BeverageTask("Boil water" , TimeSpan.FromSeconds(2)),
                new BeverageTask("Add water" , TimeSpan.FromSeconds(2)),
                new BeverageTask("Steep tea bag in hot water" , TimeSpan.FromSeconds(2)),
                new BeverageTask("Add lemon" , TimeSpan.FromSeconds(2))) ,

           
        };

        public Beverage SelectedBeverage
        {
            get => _selectedBeverage;
            set
            {
                _selectedBeverage = value;
                RaisePropertyChanged();
                if(value != null)
                    Messenger.Default.Send(new NavigateMessage(nameof(BeverageProgressView), value));
            }
        }

        public void Activated(object state)
        {
            SelectedBeverage = null;
        }
    }
}
