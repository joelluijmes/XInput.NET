using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XController
{
    class RoundToggleControl : Control
    {
        private bool _toggle;

        public bool Toggle
        {
            get
            {
                return _toggle;
            }
            set
            {
                if (_toggle == value)
                    return;

                _toggle = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (var graphics = e.Graphics)
            {
                if (Toggle)
                {
                    using (var brush = new SolidBrush(ForeColor))
                        graphics.FillEllipse(brush, 0, 0, Width, Height);
                }

                graphics.DrawEllipse(Pens.Black, 0, 0, Width - 1, Height - 1);
            }
        }
    }
}
