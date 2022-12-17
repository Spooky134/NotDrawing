using NotShapes;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace NotCircles
{
    [Serializable]
    public class NotCircle:NotShape
    {
        public override void Draw(Canvas canvas)
        {
            Ellipse el = new();
            el.Width = Math.Abs(firstPoint.X - secondPoint.X);
            el.Height = Math.Abs(firstPoint.Y - secondPoint.Y);
            el.Stroke = Brushes.White;
            el.StrokeThickness = 2;
            Canvas.SetLeft(el, firstPoint.X);
            Canvas.SetTop(el, firstPoint.Y);
            canvas.Children.Add(el);

        }

    }
}
