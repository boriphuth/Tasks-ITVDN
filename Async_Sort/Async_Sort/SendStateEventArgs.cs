using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Async_Sort
{
    public class SendStateEventArgs : RoutedEventArgs
    {
        public SendStateEventArgs(object state, object positions )
        {
            State = state;
            Positions = positions;
        }
        public object State { get; set; }
        public object Positions { get; set; }
    }
}
