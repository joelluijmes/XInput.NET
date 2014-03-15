using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XController
{
    class TriggerControl : Control
    {
        private int _progress;
        private Bitmap _image;

        public int Progress
        {
            get
            {
                return _progress;
            }
            set
            {
                if (_progress == value)
                    return;

                if (value < 0)
                    value = 0;

                if (value > 100)
                    value = 100;


                _progress = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (var graphics = e.Graphics)
            {
                using (var brush = new SolidBrush(ForeColor))
                {
                    var height = Util.Map(_progress, 0, 100, 0, Height);
                    graphics.FillRectangle(brush, new Rectangle(0, Height - height, Width, height));
                    graphics.DrawRectangle(Pens.Black, new Rectangle(0, 0, Width - 1, Height - 1));
                }
            }
        }
    }
}
