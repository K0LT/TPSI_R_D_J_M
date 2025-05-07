using System.Windows.Forms;

namespace Monster
{
    public static class FormUIInitializer
    {
        public static void InitVisibilityOptions(Panel panelFirstRegister, Button nextRegister, Button nextMonsterName)
        {
            panelFirstRegister.Visible = false; // registo player escondido
            nextRegister.Visible = false; // botao de next em registo de player
            nextMonsterName.Visible = false; //Botao next em escolher primeiro monstro escondido
        }
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