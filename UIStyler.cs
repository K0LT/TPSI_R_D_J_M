using System.Drawing;
using System.Windows.Forms;

namespace Monster.Core
{
    public static class UIStyler
    {
        public static void InitializeUI(Form form, TabControl tabControl)
        {
            form.WindowState = FormWindowState.Maximized;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Bounds = Screen.PrimaryScreen.Bounds;

            tabControl.Dock = DockStyle.Fill;
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
        }

        public static void InitializeVisibilityAndSecurity(
            TextBox descricao,
            Panel panelFirstRegister,
            Button nextRegister,
            Panel panelNextMonsterName,
            TextBox textBoxPassword)
        {
            descricao.Visible = false;
            panelFirstRegister.Visible = false;
            nextRegister.Visible = false;
            panelNextMonsterName.Visible = false;
            textBoxPassword.PasswordChar = '*';
        }

        public static void StyleMainMenuButton(Button button)
        {
            button.BackColor = Color.FromArgb(204, 255, 255, 255);

            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button.ForeColor = Color.FromArgb(54, 39, 22);


            button.MouseHover += (s, e) =>
            {
                button.BackColor = Color.FromArgb(102, 255, 255, 255);
                button.ForeColor = Color.White;
            };

            button.MouseLeave += (s, e) =>
            {
                button.BackColor = Color.FromArgb(204, 255, 255, 255);
                button.ForeColor = Color.FromArgb(54, 39, 22);
            };
        }

        //Design de botoes de menu monstro / player
        public static void StyleMonsterMenuButton(Button button)
        {
            button.BackColor = Color.FromArgb(74, 59, 42);

            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(114, 99, 82);
            button.ForeColor = Color.Peru;

            button.MouseHover += (s, e) =>
            {
                button.BackColor = Color.FromArgb(114, 99, 82);
            };

            button.MouseLeave += (s, e) =>
            {
                button.BackColor = Color.FromArgb(74, 59, 42);
                button.ForeColor = Color.Peru;
            };
        }
    }
}
