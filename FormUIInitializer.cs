using System.Windows.Forms;

namespace Monster.Core
{
    public static class FormUIInitializer
    {
        public static void InitMainMenuButtons(params Button[] buttons)
        {
            foreach (var btn in buttons)
                UIStyler.StyleMainMenuButton(btn);
        }

        public static void InitMonsterMenuButtons(params Button[] buttons)
        {
            foreach (var btn in buttons)
                UIStyler.StyleMonsterMenuButton(btn);
        }
    }
}