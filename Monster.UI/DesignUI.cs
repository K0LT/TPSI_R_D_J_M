// DesignUI.cs
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Monster.UI
{


    // Desing Progress Bar
    public class GoldProgressBar : ProgressBar
    {
        public GoldProgressBar()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            ForeColor = Color.Gold;
            BackColor = Color.AntiqueWhite;
            Minimum = 0;
            Maximum = 100;
            Value = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = this.ClientRectangle;

            using (SolidBrush backgroundBrush = new SolidBrush(BackColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, rect);
            }

            int range = Maximum - Minimum;
            float percent = 0f;
            if (range > 0)
            {
                percent = (float)(Value - Minimum) / range;
            }

            int fillWidth = (int)(rect.Width * percent);
            if (fillWidth > 0)
            {
                Rectangle fillRect = new Rectangle(rect.X, rect.Y, fillWidth, rect.Height);
                using (LinearGradientBrush fillBrush = new LinearGradientBrush(fillRect, Color.Gold, Color.DarkGoldenrod, 90F))
                {
                    e.Graphics.FillRectangle(fillBrush, fillRect);
                }
            }

            using (Pen borderPen = new Pen(Color.DarkGoldenrod))
            {
                e.Graphics.DrawRectangle(borderPen, 0, 0, rect.Width - 1, rect.Height - 1);
            }

            string percentageText = $"{(int)(percent * 100)}%";
            using (Font font = new Font("VCR OSD Mono", 14F, System.Drawing.GraphicsUnit.Point))
            {
                SizeF textSize = e.Graphics.MeasureString(percentageText, font);
                float x = (rect.Width - textSize.Width) / 2;
                float y = (rect.Height - textSize.Height) / 2;
                using (SolidBrush textBrush = new SolidBrush(Color.Black))
                {
                    e.Graphics.DrawString(percentageText, font, textBrush, x, y);
                }
            }
        }
    }


        // Design Mouse Over
          

        public static class DesignUI
        {
            private static ToolTip _toolTip = new ToolTip()
            {
                AutoPopDelay = 5000,
                InitialDelay = 500,
                ReshowDelay = 500,
                ShowAlways = true,
                OwnerDraw = true
            };

            private static Font _font = new Font("VCR OSD Mono", 14F, FontStyle.Bold);

            static DesignUI()
            {
                _toolTip.Draw += ToolTip_Draw;
                _toolTip.Popup += ToolTip_Popup;
            }

            public static void SetToolTip(Control control, string text)
            {
                _toolTip.SetToolTip(control, text);
            }

            private static void ToolTip_Draw(object sender, DrawToolTipEventArgs e)
            {
                // Custom background
                e.Graphics.FillRectangle(Brushes.LightYellow, e.Bounds);

                // Measure text size
                SizeF textSize = e.Graphics.MeasureString(e.ToolTipText, _font);

                // Calculate centered position
                float x = e.Bounds.Left + (e.Bounds.Width - textSize.Width) / 2;
                float y = e.Bounds.Top + (e.Bounds.Height - textSize.Height) / 2;

                // Draw the text centered
                e.Graphics.DrawString(e.ToolTipText, _font, Brushes.Black, x, y);
            }

            private static void ToolTip_Popup(object sender, PopupEventArgs e)
            {
                // Adjust the size of the tooltip for the custom font
                SizeF textSize;
                using (Graphics g = e.AssociatedControl.CreateGraphics())
                {
                    textSize = g.MeasureString(_toolTip.GetToolTip(e.AssociatedControl), _font);
                }
                e.ToolTipSize = textSize.ToSize();
            }
        }
    }





