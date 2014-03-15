using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XController
{
    class AxisControl : Control
    {
        private int _x;
        private int _y;

        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                if (_x == value)
                    return;

                if (value < -100)
                    value = -100;
                if (value > 100)
                    value = 100;

                _x = value;
                Invalidate();
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                if (_y == value)
                    return;

                if (value < -100)
                    value = -100;
                if (value > 100)
                    value = 100;

                _y = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (var graphics = e.Graphics)
            {
                using (var brush = new SolidBrush(Color.FromArgb(50, BackColor)))
                {
                    var x = Util.Map(_x, -100, 100, 0, Width);
                    var y = Util.Map(_y, -100, 100, 0, Height);

                    graphics.FillRectangle(brush, new Rectangle(0, 0, Width, Height));
                    graphics.DrawRectangle(Pens.Black, new Rectangle(0, 0, Width - 1, Height - 1));
                    graphics.DrawLine(Pens.Black, x, 0, x, Height);
                    graphics.DrawLine(Pens.Black, 0, y, Width, y);

                }
            }
        }
    }
}
