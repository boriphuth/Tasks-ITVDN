using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Async_Sort
{
    public class Controller
    {
        public Controller(MainWindow view)
        {
            this.view = view;
            model = new Model();
            view.SendStart += model.OnSendStart;
            model.SendArray1 += view.OnSendArray1;
            model.SendArray2 += view.OnSendArray2;
            model.SendArray3 += view.OnSendArray3;
        }
                
        public Model model;
        MainWindow view;
    }
}
