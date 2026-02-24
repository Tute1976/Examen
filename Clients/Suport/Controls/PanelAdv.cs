using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Examen.Suport.Controls
{
    [DesignerCategory("Code")]
    public sealed class PanelAdv : Panel
    {
        private int _shadowSize = 5;
        private Color _shadowColor = Color.Gray;
        private int _cornerRadius = 8;
        private Color _borderColor = Color.Silver;
        private int _borderThickness = 1;

        private int _stripeWidth = 8;
        private Color _stripeColor = Color.DeepSkyBlue;

        [Browsable(true), Category("Apariencia"), Description("Desplaçament (px) de l'ombra")]
        [DefaultValue(5)]
        public int ShadowSize
        {
            get => _shadowSize;
            set { _shadowSize = value < 0 ? 0 : value; Invalidate(); UpdateRegion(); }
        }

        [Browsable(true), Category("Apariencia"), Description("Color de l'ombra")]
        [DefaultValue(typeof(Color), "Gray")]
        public Color ShadowColor
        {
            get => _shadowColor;
            set { _shadowColor = value; Invalidate(); }
        }

        [Browsable(true), Category("Apariencia"), Description("Radi de les cantonades (px)")]
        [DefaultValue(8)]
        public int CornerRadius
        {
            get => _cornerRadius;
            set { _cornerRadius = value < 0 ? 0 : value; Invalidate(); UpdateRegion(); }
        }

        [Browsable(true), Category("Apariencia"), Description("Color de la vora")]
        [DefaultValue(typeof(Color), "Silver")]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        [Browsable(true), Category("Apariencia"), Description("Gruix de la vora (px)")]
        [DefaultValue(1)]
        public int BorderThickness
        {
            get => _borderThickness;
            set { _borderThickness = value < 0 ? 0 : value; Invalidate(); UpdateRegion(); }
        }

        [Browsable(true), Category("Apariencia"), Description("Amplada de la franja esquerra (px). Posa 0 per desactivar.")]
        [DefaultValue(8)]
        public int StripeWidth
        {
            get => _stripeWidth;
            set { _stripeWidth = value < 0 ? 0 : value; Invalidate(); }
        }

        [Browsable(true), Category("Apariencia"), Description("Color de la franja esquerra")]
        [DefaultValue(typeof(Color), "DeepSkyBlue")]
        public Color StripeColor
        {
            get => _stripeColor;
            set { _stripeColor = value; Invalidate(); }
        }

        public PanelAdv()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.White;
            Resize += (_, _) => UpdateRegion();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Àrea frontal (on es pinta el panel visible)
            var frontRect = new Rectangle(0, 0, Width - ShadowSize - 1, Height - ShadowSize - 1);

            // Ombra (mateixa forma, desplaçada)
            if (ShadowSize > 0)
            {
                var shadowRect = new Rectangle(ShadowSize, ShadowSize, frontRect.Width, frontRect.Height);
                using var shadowPath = CreateRoundRect(shadowRect, CornerRadius);
                using var shadowBrush = new SolidBrush(Color.FromArgb(80, ShadowColor));
                g.FillPath(shadowBrush, shadowPath);
            }

            // Cos del panel + franja
            using var frontPath = CreateRoundRect(frontRect, CornerRadius);

            // Clip perquè tot quedi retallat per les cantonades arrodonides
            var oldClip = g.Clip;
            g.SetClip(frontPath);

            // Fons
            using (var fill = new SolidBrush(BackColor))
                g.FillPath(fill, frontPath);

            // Franja esquerra (si s'ha definit)
            if (StripeWidth > 0)
            {
                var stripeRect = new Rectangle(0, 0, System.Math.Min(StripeWidth, frontRect.Width), frontRect.Height);
                using var stripeBrush = new SolidBrush(StripeColor);
                g.FillRectangle(stripeBrush, stripeRect);
            }

            // Restaurar clip
            g.SetClip(oldClip, CombineMode.Replace);

            // Vora
            if (BorderThickness <= 0) 
                return;
            
            using var pen = new Pen(BorderColor, BorderThickness);
            pen.Alignment = PenAlignment.Inset;
            g.DrawPath(pen, frontPath);
        }

        private void UpdateRegion()
        {
            // Ajusta la regió clicable a la forma arrodonida del frontal (sense ombra)
            var frontRect = new Rectangle(0, 0, Width - ShadowSize, Height - ShadowSize);
            using var path = CreateRoundRect(frontRect, CornerRadius);
            Region?.Dispose();
            Region = new Region(path);
        }

        private static GraphicsPath CreateRoundRect(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();

            if (radius <= 0)
            {
                path.AddRectangle(rect);
                path.CloseFigure();
                return path;
            }

            // Evitar radi massa gran
            var maxR = System.Math.Min(rect.Width, rect.Height) / 2;
            if (radius > maxR) radius = maxR;
            var d = radius * 2;

            // Cantonades
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);                  // TL
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);          // TR
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);   // BR
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);          // BL
            path.CloseFigure();
            return path;
        }
    }
}
