using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menues
{
    public class MainMenu : BaseMenu
    {
        [SerializeField] private Button singleGameButton;
        [SerializeField] private Button multiGameButton;
        [SerializeField] private Button optionsButton;
        [SerializeField] private Button exitGameButton;
    

    
        public Action<GameType> SingleMultiButtonAction;
        public Action OptionsButtonAction;


        public override void Init()
        {
            GetChildrenRect();
        
            singleGameButton.onClick.AddListener(SingleButtonDown);
            multiGameButton.onClick.AddListener(MultiButtonDown);
            // exitGameButton.onClick.AddListener(BackButtonDown);
            optionsButton.onClick.AddListener(OptionsButtonDown);


            // gameObject.SetActive(false);
        }
        private void SingleButtonDown()
        {
            SingleMultiButtonAction?.Invoke(GameType.Single);
        }

        private void MultiButtonDown()
        {
            SingleMultiButtonAction?.Invoke(GameType.Multi);
        }
        private void OptionsButtonDown()
        {
            OptionsButtonAction?.Invoke();
        }

    }
}
