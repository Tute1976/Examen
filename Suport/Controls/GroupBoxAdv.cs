using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
// ReSharper disable MemberCanBePrivate.Global

namespace Examen.Suport.Controls
{
    [DesignerCategory("Code")]
    public sealed class GroupBoxAdv : GroupBox
    {
        private int _borderWidth = 5;
        private Color _borderColor = Color.Gray;

        [Browsable(true), Category("Apariencia"), Description("Grosor del margen")]
        [DefaultValue(1)]
        public int BorderWidth
        {
            get => _borderWidth;
            set { _borderWidth = value < 0 ? 0 : value; Invalidate();}
        }

        [Browsable(true), Category("Apariencia"), Description("Color del margen")]
        [DefaultValue(typeof(Color), "Black")]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        public GroupBoxAdv()
        {
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Comprova si està en mode disseny
            if (Site is { DesignMode: true })
            {
                base.OnPaint(e); // Evita errors en mode disseny
                return;
            }

            // Esborra fons
            e.Graphics.Clear(BackColor);

            var textSize = TextRenderer.MeasureText(Text, Font);
            var borderRect = new Rectangle(0, textSize.Height / 2, Width - 1, Height - textSize.Height / 2 - 1);
            var textRect = new Rectangle(10, 0, textSize.Width + 2, textSize.Height);

            using var pen = new Pen(_borderColor, _borderWidth);
            e.Graphics.DrawRectangle(pen, borderRect);

            e.Graphics.FillRectangle(new SolidBrush(BackColor), textRect);
            TextRenderer.DrawText(e.Graphics, Text, Font, textRect.Location, ForeColor);
        }
    }
}
