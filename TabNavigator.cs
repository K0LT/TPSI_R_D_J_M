using System.Windows.Forms;

namespace Monster.Core
{
    public static class TabNavigator
    {
        public static void SwitchTo(TabControl tabControl, TabPage tabPage)
        {

            tabControl.SuspendLayout();
            tabControl.SelectedTab = tabPage;
            tabControl.ResumeLayout();
        }

    }
}