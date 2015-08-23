using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rectangles.UI.ViewModels;

namespace Rectangles.UI.Test
{
    [TestFixture]
    public class ViewModelTests
    {
        [Test]
        [STAThread]
        public void CanLaunch()
        {
            RectangleDialogViewModel rectangleDialogViewModel = new RectangleDialogViewModel();
        }
    }
}
