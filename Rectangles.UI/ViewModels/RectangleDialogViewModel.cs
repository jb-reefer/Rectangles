using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rectangles.UI.Views;
using Rectangles.Objects;

namespace Rectangles.UI.ViewModels
{
    // TODO: This is horrible, do an mvvm tutorial and fix it
    public class RectangleDialogViewModel 
    {
        public ObservableCollection<ViewRectangle> Rectangles;

        public RectangleDialogViewModel()
        {
            // TODO: Put in the rectangles from storage here
            Rectangles = new ObservableCollection<ViewRectangle>();
            //RectangleDialog dialog = RectangleDialog.;

            //dialog.Show();
        }

        public bool TestContain(ViewRectangle rectangleA, ViewRectangle rectangleB)
        {
            Rectangle firstRectangle = rectangleA.ConvertToRectangle();
            Rectangle secondRectangle = rectangleB.ConvertToRectangle();

            return firstRectangle.Contains(secondRectangle);
        }

        public ViewRectangle GetIntersection(ViewRectangle rectangleA, ViewRectangle rectangleB)
        {
            Rectangle firstRectangle = rectangleA.ConvertToRectangle();
            Rectangle secondRectangle = rectangleB.ConvertToRectangle();

            return new ViewRectangle( firstRectangle.GetIntersection(secondRectangle));
        }

        public ViewRectangle GetContained(ViewRectangle rectangleA, ViewRectangle rectangleB)
        {
            Rectangle firstRectangle = rectangleA.ConvertToRectangle();
            Rectangle secondRectangle = rectangleB.ConvertToRectangle();

            if (firstRectangle.Contains(secondRectangle))
            {
                return rectangleB;
            }

            return new ViewRectangle(null);

        }
    }
}
