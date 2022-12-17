using System;
using System.Windows;
using System.Windows.Controls;

namespace NotShapes
{      
    [Serializable]
    public class NotShape
    {
        public Point firstPoint;

        public Point secondPoint;
       
        public Point GetFirstPoint()
        {
            return firstPoint;
        }
        public void SetFirstPoint(Point firstPoint)
        {
            this.firstPoint = firstPoint;
        }
        public Point GetSecondPoint()
        {
            return secondPoint;
        }
        public void SetSecondPoint(Point secondPoint)
        {
            this.secondPoint = secondPoint;
        }
        public virtual void Draw(Canvas canvas) { }
    }
}
