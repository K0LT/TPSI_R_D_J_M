using System.Runtime.CompilerServices;
using Monster.Game.GameState;

namespace Monster.UI
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            Console.WriteLine(@"[DEBUG] Form1 Init.");

            var gameState = new GameState();
            Console.WriteLine(@"[DEBUG] GameState Init.");
            var gameDataService = new GameDataService();
            Console.WriteLine(@"[DEBUG] GameDataService Init.");

            BindingSource _bsMonster = new BindingSource();

            Console.WriteLine(@"[DEBUG] Monster Binding Source Init.");

            InitializeComponent();
            Console.WriteLine(@"Form 1 Component Init Call.");

            UserControl myMonsterUC = new myMonster();

            BindingSourcesStateLink(gameState, _bsMonster);
            Console.WriteLine(@"[DEBUG] Creating binding sources.");

            LinkBindingsUI(_bsMonster, myMonsterUC);
            
        }

        public void BindingSourcesStateLink(GameState state, BindingSource bsMonster)
        {
            bsMonster.DataSource = state.ActiveMonster;
        }

        public void LinkBindingsUI(BindingSource bsMonster, myMonster myMonsterControl)
        {
            bsMonster.DataMember = myMonsterControl.
        }
    }
}
