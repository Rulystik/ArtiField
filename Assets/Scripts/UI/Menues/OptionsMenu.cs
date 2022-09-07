using UnityEngine;
using UnityEngine.UI;

namespace UI.Menues
{
    public class OptionsMenu : BaseMenu
    {
        [SerializeField] private Button backButton;
        public void OnEnable()
        {
            GetChildrenRect();
            // backButton.onClick.AddListener();
            gameObject.SetActive(false);
        }
    }
}
