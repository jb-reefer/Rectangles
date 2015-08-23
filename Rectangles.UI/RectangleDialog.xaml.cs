using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Rectangles.UI.ViewModels;
using Rectangles.UI.Views;

namespace Rectangles.UI
{
    /// <summary>
    /// Interaction logic for RectangleDialog.xaml
    /// </summary>
    public partial class RectangleDialog : Window
    {
        public new RectangleDialogViewModel DataContext;
        private bool _notFirstRectangle;

        public RectangleDialog()
        {
            InitializeComponent();
            DataContext = new RectangleDialogViewModel();
            _notFirstRectangle = false;
        }

        private void DrawRectange_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void CheckContainment_Click(object sender, RoutedEventArgs e)
        {
            List<ViewRectangle> containedAreas = new List<ViewRectangle>();
            // Go through all of the rectangles on the page, compare them to each other for intersection
            for (int i = 0; i < DataContext.Rectangles.Count; i++)
            {
                for (int j = 0; j < DataContext.Rectangles.Count; j++)
                {
                    if (i != j)
                    {
                        ViewRectangle area = DataContext.GetContained(DataContext.Rectangles[i], DataContext.Rectangles[j]);
                        if (area.Equals(null))
                        {
                            continue;
                        }

                        containedAreas.Add(area);
                    }
                }
            }

            ColorIntersectingRectangles(containedAreas);

        }

        private void ColorRectangles(List<UIElement> rectangles, Color fillColor)
        {
            foreach (Rectangle child in rectangles)
            {
                child.Fill = new SolidColorBrush(fillColor);
            }
        }

        private void ColorIntersectingRectangles(List<ViewRectangle> viewRectangles )
        {

            foreach (ViewRectangle area in viewRectangles.Where( vr => !DataContext.Rectangles.Contains(vr) ))
            {
                AddRectangle(area.StartX, area.StartY, area.Width, area.Height);

                // TODO: This is kludgy, use databinding
                ((Rectangle) RectCanvas.Children[RectCanvas.Children.Count - 1]).Fill = new SolidColorBrush(Colors.SpringGreen);
            }
        }

        private void AddRectangle(double startX, double startY, double width, double height)
        {
            ViewRectangle viewRectangle = new ViewRectangle(startX, startY, width, height);
            DataContext.Rectangles.Add(viewRectangle);
            _notFirstRectangle = true;

            Rectangle rect = new Rectangle { Width = width, Height = width, Stroke = Brushes.Black };
            RectCanvas.Children.Add(rect);
            Canvas.SetLeft(rect, startX);
            Canvas.SetTop(rect, startY);
        }

        // TODO: This is the guts of something that will work but it's shit right now
        private void RectCanvas_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Draw a big rectangle
            int height = 300;
            int width = 300;
            if (_notFirstRectangle)
            {
                height = 50;
                width = 75;
            }

            // Add to the canvas
            AddRectangle(e.GetPosition(this).X, e.GetPosition(this).Y, width, height);            
        }

        private void CheckIntersection_Click(object sender, RoutedEventArgs e)
        {
            List<ViewRectangle> intersectionAreas = new List<ViewRectangle>();
            // Go through all of the rectangles on the page, compare them to each other for intersection
            for (int i = 0; i < DataContext.Rectangles.Count; i++)
            {
                for (int j = 0; j < DataContext.Rectangles.Count; j++)
                {
                    if (i != j)
                    {
                        ViewRectangle intersection = DataContext.GetIntersection(DataContext.Rectangles[i], DataContext.Rectangles[j]);
                        if (intersection.Equals(null))
                        {
                            continue;
                        }

                        intersectionAreas.Add(intersection);
                    }
                }
            }

            ColorIntersectingRectangles(intersectionAreas);

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            DataContext.Rectangles.Clear();
            RectCanvas.Children.Clear();
        }
    }


}
