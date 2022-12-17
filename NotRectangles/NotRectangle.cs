using NotShapes;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace NotRectangles
{
    [Serializable]
    public class NotRectangle:NotShape
    {
        public override void Draw(Canvas canvas)
        {
            Polygon polygon = new();
            polygon.Points.Add(new Point(firstPoint.X, firstPoint.Y));
            polygon.Points.Add(new Point(secondPoint.X, firstPoint.Y));
            polygon.Points.Add(new Point(secondPoint.X, secondPoint.Y));
            polygon.Points.Add(new Point(firstPoint.X, secondPoint.Y));

            polygon.Stroke = Brushes.White;
            polygon.StrokeThickness = 2;
            canvas.Children.Add(polygon);
        }
    }
}
