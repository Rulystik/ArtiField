using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menues
{
    public class ExitGameMenu : BaseMenu
    {
        [SerializeField] private Button yesButton;
        [SerializeField] private Button noButton;

        public Action QuitButtonAction;
        public Action BackAction;
        public override void Init()
        {
            GetChildrenRect();
        
            yesButton.onClick.AddListener(YesButtonDown);
            // noButton.onClick.AddListener(BackButtonDown);
        
            gameObject.SetActive(false);
        
        }
        private void YesButtonDown()
        {
            QuitButtonAction?.Invoke();
        }

    }
}
