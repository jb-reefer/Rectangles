using System.Collections.Generic;

namespace Rectangles.Objects
{
    /// <summary>
    /// Plane that has rectangles embedded in it
    /// </summary>
    public class Plane
    {
        // TODO: This name sucks
        public Dictionary<Point, AbstractEmbeddedRectangle> EmbeddedRectangles;

        // TODO: Is this necessary?
        // I feel like we should do this
        public Point[,] Points;

        public Plane()
        {
            
        }

        public Plane(int width, int height)
        {
            // Set up member variables
            EmbeddedRectangles = new Dictionary<Point, AbstractEmbeddedRectangle>();
            Points = new Point[width,height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Points[i,j] = new Point(i, j);
                }
            }
        }

        public void EmbedRectangle(AbstractEmbeddedRectangle rectangle)
        {
            EmbeddedRectangles.Add(rectangle.StartPoint(), rectangle);
        }

    }
}