using DG.Tweening;
using UnityEngine;

namespace UI.Menues.MenuStates
{
    public class NoneStateMenu : BaseStateMenu, IStateMenu
    {
        private GameObject _blockingScreen;

        public NoneStateMenu(IMenu nonMenu, GameObject blockingScreen) : base(nonMenu)
        {
            _blockingScreen = blockingScreen;
            _blockingScreen.SetActive(false);
        }
        
        public override float Exit(float deley = 0f)
        {
            _blockingScreen.SetActive(true);
            deley += _menu.Open(deley);
            return deley;
        }

        public override float Enter(float deley = 0f)
        {
            deley += _menu.Close(deley);
            DOVirtual.DelayedCall(deley, () => _blockingScreen.SetActive(false));
            return deley;
        }
    }
}