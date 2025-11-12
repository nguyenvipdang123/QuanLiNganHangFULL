using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DNTULoginForm
{
    public class RoundButton : Button
    {
        public int CornerRadius { get; set; } = 20;

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            UpdateRegion();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateRegion();
        }
        private void UpdateRegion()
        {
            int r = CornerRadius, d = r * 2;
            if (r <= 0 || Width <= 0 || Height <= 0) { Region = null; return; }

            using (var path = new GraphicsPath())
            {
                var rect = new Rectangle(0, 0, Width, Height);
                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                path.CloseFigure();
                Region = new Region(path);
            }
        }
    }
}
