using Core.Data;

namespace Controls
{
    public class MenuController
    {
        private Menu _menu;
        private BootData _globalData;

        public MenuController(Menu menu, BootData globalData)
        {
            _menu = menu;
            _globalData = globalData;
        }


    }
}