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
        public void OnEnable()
        {
            GetChildrenRect();
        
            yesButton.onClick.AddListener(YesButtonDown);
            noButton.onClick.AddListener(BackButtonDown);
        
            gameObject.SetActive(false);
        
        }

        private void BackButtonDown()
        {
            BackAction?.Invoke();
        }

        private void YesButtonDown()
        {
            QuitButtonAction?.Invoke();
        }

    }
}
