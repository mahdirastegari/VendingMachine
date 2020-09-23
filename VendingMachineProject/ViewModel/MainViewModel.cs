using System;
using System.Collections.Generic;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using VendingMachineProject.Messages;
using VendingMachineProject.View;

namespace VendingMachineProject.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private FrameworkElement _currentView;
        Dictionary<string, FrameworkElement> _views;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            _views = new Dictionary<string, FrameworkElement>();
            Messenger.Default.Register<NavigateMessage>(this, (message) => OnNavigate(message));
            SetupView(new BeverageMenuView(), new BeverageMenuViewModel());
            SetupView(new BeverageProgressView(), new BeverageProgressViewModel());
            OnNavigate(new NavigateMessage(nameof(BeverageMenuView), null));
        }



        private void SetupView(FrameworkElement view, ViewModelBase viewModel)
        {
            if (viewModel != null)
                view.DataContext = viewModel;
            _views.Add(view.GetType().Name, view);
        }

        private void OnNavigate(NavigateMessage message)
        {
            IView view = null;
            App.Current.Dispatcher.Invoke(() =>
            {
                this.CurrentView = _views[message.TargetView];
                view = (this.CurrentView.DataContext as IView);
            });
            view?.Activated(message.State);
        }

        public RelayCommand ExitCommand { get; set; } = new RelayCommand(()=> App.Current.Shutdown(0));
        public RelayCommand SignOutCommand { get; set; } = new RelayCommand(() => throw new NotImplementedException("Sign Out not implemented"));

        public FrameworkElement CurrentView
        {
            get { return _currentView; }
            set
            {

                _currentView = value;
                RaisePropertyChanged();

            }
        }


    }
}