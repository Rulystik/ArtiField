using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menues
{
    public class GameTypeMenu : BaseMenu
    {
        [SerializeField] private Button simpleGameButton;
        [SerializeField] private Button adnvancedGameButton;
        [SerializeField] private Button backButton;


        public Action<GameType> simpleOrAvancedButtonAction;

        public void OnEnable()
        {
            GetChildrenRect();

            simpleGameButton.onClick.AddListener(SimpleGameButtonDown);
            adnvancedGameButton.onClick.AddListener(AdvancedGameButtonDown);
            backButton.onClick.AddListener(BackButtonDown);
        
        }

        private void BackButtonDown()
        {
            BackAction?.Invoke();
        }

        private void SimpleGameButtonDown()
        {
            simpleOrAvancedButtonAction?.Invoke(GameType.Simple);
        }
        private void AdvancedGameButtonDown()
        {
            simpleOrAvancedButtonAction?.Invoke(GameType.Advanced);
        }
    }
}
