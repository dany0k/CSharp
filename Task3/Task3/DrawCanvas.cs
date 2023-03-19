using System;
using System.Collections.Generic;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace Task3
{
    public class DrawCanvas : Canvas
    {
        private SolidColorBrush _brush;
        private IList<EllipseShape> _ellipses;
        private IDictionary<EllipseShape, EllipseGeometry> _ellipsesCache;
        private EllipseShape ellipse;

            public DrawCanvas()
        {
            Random rnd = new Random();
            _ellipses = new List<EllipseShape>();
            _ellipsesCache = new Dictionary<EllipseShape, EllipseGeometry>();

            this.PointerPressed += (sender, args) =>
            {
                _brush = new SolidColorBrush(Color.Parse("aqua"));
                var p = new Point(0, 0);
                var rad = MainWindow.rad;
                ellipse = new EllipseShape(new Point(p.X, p.Y), rad);
                Debug.WriteLine(_ellipses.Count);
                this.InvalidateVisual();
            };
        }

        public override void Render(DrawingContext context)
        {
            base.Render(context);
            var geometry = new EllipseGeometry(new Rect(ellipse.X, ellipse.Y, ellipse.Width, ellipse.Height));
            context.DrawGeometry(_brush, null, geometry);
        }
    }
}