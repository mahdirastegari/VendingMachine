using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using VendingMachineProject.Messages;
using VendingMachineProject.Model;
using VendingMachineProject.View;

namespace VendingMachineProject.ViewModel
{
    public class BeverageProgressViewModel : ViewModelBase , IView
    {
        public RelayCommand BackCommand { get; set; } = new RelayCommand(
            () => Messenger.Default.Send(new NavigateMessage(nameof(BeverageMenuView), null)));

        public RelayCommand CancelCommand
        {
            get => _cancelCommand;
            set
            {
                _cancelCommand = value;
                RaisePropertyChanged();
            }
        }

     

        private Beverage _currentBeverage;
        private RelayCommand _cancelCommand;
        private RelayCommand _backCommand;

        public Beverage CurrentBeverage
        {
            get => _currentBeverage;
            set
            {
                _currentBeverage = value;
                RaisePropertyChanged();
            }
        }

        public BeverageProgressViewModel()
        {
            CancelCommand  = new RelayCommand(() => CurrentBeverage.Cancel());
        }

        public void Activated(object state)
        {
            if (!(state is Beverage beverage)) return;

            CurrentBeverage = beverage;
            CurrentBeverage.Start();
        }
    }
}
