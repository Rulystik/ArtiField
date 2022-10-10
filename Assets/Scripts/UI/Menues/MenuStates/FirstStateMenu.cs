using Core.Other;
using UnityEngine.SceneManagement;

namespace UI.Menues.MenuStates
{
    public class FirstStateMenu : BaseStateMenu, IStateMenu
    {

        public FirstStateMenu(IMenu mainMenu, IMenu pauseMenu): base(mainMenu)
        {
            if (SceneManager.GetActiveScene().name != Const.MENU_SCENE)
            {
                _menu = pauseMenu;
            }
        }
    }
}