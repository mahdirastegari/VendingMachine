using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using VendingMachineProject.Annotations;

namespace VendingMachineProject.Model
{
    public enum StatusEnum { Nothing , Canceled , InProgress , Completed}

    public class BeverageTask: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region PrivateValues
        private StatusEnum _status;
        #endregion

        #region Public Properties
        public string Title { get; private set; }
        public TimeSpan Duration { get; private set; }

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
        #endregion


        //We will not use this in the continuation of the project
        #region  Events
        public event EventHandler<StatusEnum> BeverageTaskStatusEvent;
        #endregion



        public BeverageTask(string title, TimeSpan duration)
        {
            Title = title;
            Duration = duration;
        }

        public Task Start(CancellationToken cancellationToken)
        {
            InvokeEvent(StatusEnum.InProgress);
            return Task.Delay(Duration , cancellationToken).ContinueWith(t =>
            {
                if(t.Status == TaskStatus.RanToCompletion)
                    InvokeEvent(StatusEnum.Completed);
                else
                    InvokeEvent(StatusEnum.Canceled);

            });
        }
      
        private void InvokeEvent(StatusEnum status)
        {
            Status = status;
            BeverageTaskStatusEvent?.Invoke(this, status);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
