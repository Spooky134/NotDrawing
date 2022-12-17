using NotShapes;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace NotLines
{
    [Serializable]
    public class NotLine:NotShape
    {
        public override void Draw(Canvas canvas)
        {
            Line line = new();
            line.X1 = firstPoint.X;
            line.Y1 = firstPoint.Y;

            line.X2 = secondPoint.X;
            line.Y2 = secondPoint.Y;

            line.Stroke = Brushes.White;
            line.StrokeThickness = 2;

            canvas.Children.Add(line);
        }
    }
}
