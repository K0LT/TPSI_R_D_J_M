using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monster.UI.Navigation
{
    public class NavigationManager
    {
        private readonly TabControl _tabControl;
        private readonly Dictionary<GameScreen, TabPage> _screenMap;

        public enum GameScreen
        {
            Home,
            NewGame,
            LoadGame,
            Monster,
            Inventory,
            Battle,
            Settings,
            Credits,
            Tutorial
        }

        public NavigationManager(TabControl tabControl, Dictionary<GameScreen, TabPage> screenMap)
        {
            _tabControl = tabControl;
            _screenMap = screenMap;
        }

        public void NavigateTo(GameScreen screen)
        {
            if (_screenMap.TryGetValue(screen, out TabPage page))
            {
                _tabControl.SelectedTab = page;
            }
        }
    }
}
