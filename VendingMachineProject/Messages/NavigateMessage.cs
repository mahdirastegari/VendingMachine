using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineProject.Messages
{
    public class NavigateMessage
    {
        public string TargetView { get; private set; }
        public object State { get; private set; }

        public NavigateMessage(string targetView, object state)
        {
            this.TargetView = targetView;
            this.State = state;
        }
    }
}
