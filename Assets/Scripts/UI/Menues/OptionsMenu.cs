using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menues
{
    public class OptionsMenu : BaseMenu, IMenu
    {
        [SerializeField] private Button backButton;

        public Action BackButtonAction;
        public void OnEnable()
        {
            GetChildrenRect();
            backButton.onClick.AddListener(BackButtonDown);
            SetScaleZero();
        }

        private void BackButtonDown()
        {
            BackButtonAction?.Invoke();
        }
    }
}
