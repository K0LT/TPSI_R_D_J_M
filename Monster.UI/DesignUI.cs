using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Monster.UI
{
    /// <summary>
    /// A custom gold-themed progress bar for visual consistency in the game UI.
    /// Overrides default rendering with a gradient fill and stylized percentage text.
    /// </summary>
    public class GoldProgressBar : ProgressBar
    {
        public GoldProgressBar()
        {
            // Enable custom drawing and optimized double buffering for smoother visuals
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

            // Set default colors and range
            ForeColor = Color.Gold;
            BackColor = Color.AntiqueWhite;
            Minimum = 0;
            Maximum = 100;
            Value = 0;
        }

        /// <summary>
        /// Custom paint logic for the progress bar.
        /// Renders background, progress fill with gradient, border, and percentage text.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = this.ClientRectangle;

            // Draw background
            using (SolidBrush backgroundBrush = new SolidBrush(BackColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, rect);
            }

            // Calculate progress percentage
            int range = Maximum - Minimum;
            float percent = 0f;
            if (range > 0)
            {
                percent = (float)(Value - Minimum) / range;
            }

            // Draw the filled portion using a vertical gold gradient
            int fillWidth = (int)(rect.Width * percent);
            if (fillWidth > 0)
            {
                Rectangle fillRect = new Rectangle(rect.X, rect.Y, fillWidth, rect.Height);
                using (LinearGradientBrush fillBrush = new LinearGradientBrush(fillRect, Color.Gold, Color.DarkGoldenrod, 90F))
                {
                    e.Graphics.FillRectangle(fillBrush, fillRect);
                }
            }

            // Draw border
            using (Pen borderPen = new Pen(Color.DarkGoldenrod))
            {
                e.Graphics.DrawRectangle(borderPen, 0, 0, rect.Width - 1, rect.Height - 1);
            }

            // Draw centered percentage text
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

    /// <summary>
    /// Provides consistent visual styling for tooltips across the game UI.
    /// Includes owner-drawn tooltip appearance and font styling.
    /// </summary>
    public static class DesignUI
    {
        // Shared tooltip instance with custom draw and popup behavior
        private static ToolTip _toolTip = new ToolTip()
        {
            AutoPopDelay = 5000,
            InitialDelay = 500,
            ReshowDelay = 500,
            ShowAlways = true,
            OwnerDraw = true // Enables custom drawing of the tooltip
        };

        // Custom font used for tooltip text
        private static Font _font = new Font("VCR OSD Mono", 14F, FontStyle.Bold);

        // Static constructor wires up the draw and popup events
        static DesignUI()
        {
            _toolTip.Draw += ToolTip_Draw;
            _toolTip.Popup += ToolTip_Popup;
        }

        /// <summary>
        /// Assigns a custom-styled tooltip to a control.
        /// </summary>
        public static void SetToolTip(Control control, string text)
        {
            _toolTip.SetToolTip(control, text);
        }

        /// <summary>
        /// Custom rendering for tooltip content.
        /// Draws a yellow background and centers bold text.
        /// </summary>
        private static void ToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.LightYellow, e.Bounds);

            SizeF textSize = e.Graphics.MeasureString(e.ToolTipText, _font);
            float x = e.Bounds.Left + (e.Bounds.Width - textSize.Width) / 2;
            float y = e.Bounds.Top + (e.Bounds.Height - textSize.Height) / 2;

            e.Graphics.DrawString(e.ToolTipText, _font, Brushes.Black, x, y);
        }

        /// <summary>
        /// Adjusts tooltip size to fit the custom font and text content.
        /// </summary>
        private static void ToolTip_Popup(object sender, PopupEventArgs e)
        {
            SizeF textSize;
            using (Graphics g = e.AssociatedControl.CreateGraphics())
            {
                textSize = g.MeasureString(_toolTip.GetToolTip(e.AssociatedControl), _font);
            }
            e.ToolTipSize = textSize.ToSize();
        }
    }
}
