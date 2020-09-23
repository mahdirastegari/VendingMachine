using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using VendingMachineProject.Annotations;

namespace VendingMachineProject.Model
{
    public class Beverage : INotifyPropertyChanged
    {
        public string Title { get; private set; }
        public BitmapSource Image { get; private set; }
        public IReadOnlyList<BeverageTask> BeverageTasks { get; private set; } 

        private CancellationTokenSource _cancellationTokenSource;
        private StatusEnum _status;

        public Beverage(string title, BitmapSource image, params BeverageTask[] beverageTask)
        {
            Title = title;
            Image = image;
            BeverageTasks = beverageTask.ToList();
        }

        public StatusEnum Status
        {
            get => _status;
            set
            {
                if (value == _status) return;
                _status = value;
                OnPropertyChanged();
            }
        }

        public async void Start()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            Status = StatusEnum.InProgress;
            foreach (var beverageTask in BeverageTasks)
            {
                beverageTask.Status = StatusEnum.InProgress;
            }
            foreach (var beverageTask in BeverageTasks)
            {
                await beverageTask.Start(_cancellationTokenSource.Token);
            }

            Status = BeverageTasks.All(t=>t.Status == StatusEnum.Completed) ? StatusEnum.Completed : StatusEnum.Canceled;
        }

        public void Cancel()=> _cancellationTokenSource.Cancel();


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
