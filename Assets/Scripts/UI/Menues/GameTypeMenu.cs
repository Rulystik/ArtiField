using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menues
{
    public class GameTypeMenu : BaseMenu, IMenu
    {
        [SerializeField] private Button simpleGameButton;
        [SerializeField] private Button adnvancedGameButton;
        [SerializeField] private Button backButton;


        public Action<GameType> simpleOrAdvancedButtonAction;
        public Action BackButtonAction;

        public void OnEnable()
        {
            GetChildrenRect();

            simpleGameButton.onClick.AddListener(SimpleGameButtonDown);
            adnvancedGameButton.onClick.AddListener(AdvancedGameButtonDown);
            backButton.onClick.AddListener(BackButtonDown);
            
            SetScaleZero();
        }

        private void BackButtonDown()
        {
            BackButtonAction?.Invoke();
        }

        private void SimpleGameButtonDown()
        {
            simpleOrAdvancedButtonAction?.Invoke(GameType.Simple);
        }
        private void AdvancedGameButtonDown()
        {
            simpleOrAdvancedButtonAction?.Invoke(GameType.Advanced);
        }
    }
}
