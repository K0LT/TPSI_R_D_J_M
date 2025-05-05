using System.Windows.Forms;

namespace Monster.Core
{
    public static class ImageDescriptionBinder
    {
        public static void Bind(PictureBox image, TextBox description)
        {
            if (image == null || description == null)
                return;

            description.Visible = false;

            image.MouseEnter += (s, e) =>
            {
                description.Visible = true;
                description.BringToFront();
            };

            image.MouseLeave += (s, e) =>
            {
                description.Visible = false;
            };
        }
    }
}
