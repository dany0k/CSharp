using System;

namespace Task3
{
    public class EllipseShape
    {
        private double _x;
        private double _y;
        private double _radius;
        public EllipseShape(Point point, double radius)
        {
            _radius = radius;
            _x = point.X;
            _y = point.Y;
            this.Width = radius * 2;
            this.Height = radius * 2;
        }

        public bool IsPointInside(Point point)
        {
            var h = Math.Pow((point.X - _x), 2) + Math.Pow((point.Y - _y), 2);
            if (h <= _radius * _radius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double X
        {
            get => _x;
            set => _x = value;
        }

        public double Y
        {
            get => _y;
            set => _y = value;
        }

        public double Width { get; set; }
        public double Height { get; set; }
    }
}