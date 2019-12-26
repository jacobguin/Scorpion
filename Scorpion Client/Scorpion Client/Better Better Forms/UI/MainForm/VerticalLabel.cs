using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Scorpion_Client.Better_Better_Forms.UI.MainForm
{
    public class VerticalLabel: Label
    {
        public int RotateAngle { get; set; }
        public string NewText { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            Brush b = new SolidBrush(ForeColor);
            e.Graphics.TranslateTransform(Width / 2, Height / 2);
            e.Graphics.RotateTransform(RotateAngle);
            e.Graphics.DrawString(NewText, Font, b, 0f, 0f);
            base.OnPaint(e);
        }
    }
}
