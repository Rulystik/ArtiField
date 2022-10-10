using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menues
{
    public class ExitGameMenu : BaseMenu, IMenu
    {
        [SerializeField] private Button yesButton;
        [SerializeField] private Button noButton;

        public Action QuitButtonAction;
        public Action NoButtonAction;
        public void OnEnable()
        {
            GetChildrenRect();
        
            yesButton.onClick.AddListener(YesButtonDown);
            noButton.onClick.AddListener(NoButtonDown);
            
            SetScaleZero();
        }

        private void NoButtonDown()
        {
            NoButtonAction?.Invoke();
        }


        private void YesButtonDown()
        {
            QuitButtonAction?.Invoke();
        }

    }
}
