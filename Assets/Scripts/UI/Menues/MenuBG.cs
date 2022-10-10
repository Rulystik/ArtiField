using UI.Menues;
using UnityEngine;

public class MenuBg : BaseMenu, IMenu
{
    private void OnEnable()
    {
        GetChildrenRect();
        SetScaleZero();
    }
}
