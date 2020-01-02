namespace Scorpion_Client.Better_Better_Forms.UI.MainForm
{
    using System.Drawing;
    using System.Windows.Forms;

    public class TextBoxWithWaterMark : TextBox
    {
        public string Watermark { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            Brush b = new SolidBrush(Color.Black);
            e.Graphics.DrawString(Watermark, Font, b, 5, 5);
            base.OnPaint(e);
        }
    }
}
