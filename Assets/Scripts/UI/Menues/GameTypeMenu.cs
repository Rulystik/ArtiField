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

        public override void Init()
        {
            GetChildrenRect();

            simpleGameButton.onClick.AddListener(SimpleGame);
            adnvancedGameButton.onClick.AddListener(AdvancedGame);
            // backButton.onClick.AddListener(BackButtonDown);
        
            gameObject.SetActive(false);
        }
        private void SimpleGame()
        {
            simpleOrAvancedButtonAction?.Invoke(GameType.Simple);
        }
        private void AdvancedGame()
        {
            simpleOrAvancedButtonAction?.Invoke(GameType.Advanced);
        }
    }
}
