using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menues
{
    public class PauseMenu : BaseMenu, IMenu
    {
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button leaveButton;
        [SerializeField] private Button optionsButton;
        [SerializeField] private Button exitButton;

        public Action LeaveButtonAction;
        public Action ExitButtonAction;
        public Action OptionsButtonAction;
        public Action BackButtonAction;
    
        public void OnEnable()
        {
            GetChildrenRect();
            leaveButton.onClick.AddListener(LeaveTheGame);
            optionsButton.onClick.AddListener(OptionsButtonDown);
            exitButton.onClick.AddListener(ExitGame);
            resumeButton.onClick.AddListener(BackButtonDown);
            SetScaleZero();
        }

        private void BackButtonDown()
        {
            BackButtonAction?.Invoke();
        }

        private void OptionsButtonDown()
        {
            OptionsButtonAction?.Invoke();
        }

        private void ExitGame()
        {
            ExitButtonAction?.Invoke();
        }

        private void LeaveTheGame()
        {
            LeaveButtonAction?.Invoke();
        }
    }
}
