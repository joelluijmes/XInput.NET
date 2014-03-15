using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XInput;
using Button = XInput.Button;

namespace XController
{
    public unsafe partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var controller = new XboxController(0);
            controller.ButtonUp += ControllerOnButtonUp;
            controller.ButtonDown += ControllerOnButtonDown;
            controller.TriggerChanged += ControllerOnTriggerChanged;
            controller.StickChanged += ControllerOnStickChanged;
        }

        private void ControllerOnStickChanged(object sender, StickEventArgs stickEventArgs)
        {
            var x = stickEventArgs.X*100/32767;
            var y = stickEventArgs.Y*-100/32767;
            if (stickEventArgs.Side == Side.Left)
                Invoke((MethodInvoker) (() =>
                {
                    axisControl1.X = x;
                    axisControl1.Y = y;
                }));
            else
                Invoke((MethodInvoker)(() =>
                {
                    axisControl2.X = x;
                    axisControl2.Y = y;
                }));
        }

        private void ControllerOnTriggerChanged(object sender, TriggerEventArgs triggerEventArgs)
        {
            var value = triggerEventArgs.Value*100/255;
            if (triggerEventArgs.Side == Side.Left)
                Invoke((MethodInvoker) (() => triggerControl1.Progress = value));
            else
                Invoke((MethodInvoker)(() => triggerControl2.Progress = value));
        }

        private void ControllerOnButtonDown(object sender, ButtonEventArgs buttonEventArgs)
        {
            if ((buttonEventArgs.Button & Button.A) != 0)
                Invoke((MethodInvoker) (() => roundToggleControl1.Toggle = true));
            
            if ((buttonEventArgs.Button & Button.B) != 0)
                Invoke((MethodInvoker)(() => roundToggleControl2.Toggle = true));

            if ((buttonEventArgs.Button & Button.Y) != 0)
                Invoke((MethodInvoker)(() => roundToggleControl3.Toggle = true));

            if ((buttonEventArgs.Button & Button.X) != 0)
                Invoke((MethodInvoker)(() => roundToggleControl4.Toggle = true));

            if ((buttonEventArgs.Button & Button.BACK) != 0)
                Invoke((MethodInvoker)(() => roundToggleControl5.Toggle = true));

            if ((buttonEventArgs.Button & Button.START) != 0)
                Invoke((MethodInvoker)(() => roundToggleControl6.Toggle = true));

            if ((buttonEventArgs.Button & Button.LEFT_SHOULDER) != 0)
                Invoke((MethodInvoker)(() => roundToggleControl7.Toggle = true));

            if ((buttonEventArgs.Button & Button.RIGHT_SHOULDER) != 0)
                Invoke((MethodInvoker)(() => roundToggleControl8.Toggle = true));


        }

        private void ControllerOnButtonUp(object sender, ButtonEventArgs buttonEventArgs)
        {
            if ((buttonEventArgs.Button & Button.A) != 0)
                Invoke((MethodInvoker)(() => roundToggleControl1.Toggle = false));

            if ((buttonEventArgs.Button & Button.B) != 0)
                Invoke((MethodInvoker)(() => roundToggleControl2.Toggle = false));

            if ((buttonEventArgs.Button & Button.Y) != 0)
                Invoke((MethodInvoker)(() => roundToggleControl3.Toggle = false));

            if ((buttonEventArgs.Button & Button.X) != 0)
                Invoke((MethodInvoker)(() => roundToggleControl4.Toggle = false));

            if ((buttonEventArgs.Button & Button.BACK) != 0)
                Invoke((MethodInvoker)(() => roundToggleControl5.Toggle = false));

            if ((buttonEventArgs.Button & Button.START) != 0)
                Invoke((MethodInvoker)(() => roundToggleControl6.Toggle = false));

            if ((buttonEventArgs.Button & Button.LEFT_SHOULDER) != 0)
                Invoke((MethodInvoker)(() => roundToggleControl7.Toggle = false));

            if ((buttonEventArgs.Button & Button.RIGHT_SHOULDER) != 0)
                Invoke((MethodInvoker)(() => roundToggleControl8.Toggle = false));
        }
    }
}
