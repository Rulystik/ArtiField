using Core.Data;

namespace Controls
{
    public class MenuController
    {
        private MenuView menuView;
        private RunTimeData _globalData;

        public MenuController(MenuView menuView, RunTimeData globalData)
        {
            this.menuView = menuView;
            _globalData = globalData;
        }


    }
}