using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rectangles.UI.ViewModels;

namespace Rectangles.UI
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            //RectangleDialogViewModel rectangleDialogViewModel = new RectangleDialogViewModel();
            RectangleDialog dialog = new RectangleDialog();
            dialog.ShowDialog();
        }
    }
}
