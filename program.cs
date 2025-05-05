using System;
using System.Windows.Forms;

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        ClickGameForm form = new ClickGameForm();
        ClickGameLogic logic = new ClickGameLogic(form);

        Application.Run(form);
    }
}