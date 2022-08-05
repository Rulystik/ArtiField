using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class MenuBehavior
{
    private List<MenuBase> MenuList { get;}
    private RectTransform menuBG;

    private Dictionary<int, MenuBase> queueMenuDic;
    
    public  MenuBehavior(List<MenuBase> list)
    {
        queueMenuDic = new Dictionary<int, MenuBase>();
        MenuList = new List<MenuBase>();
        foreach (var menuBase in list)
        {
            MenuList.Add(menuBase);
        }
        menuListInit();
        menuBG = MenuList.FirstOrDefault().transform.parent.GetComponent<RectTransform>();
    }
    private void menuListInit()
    {
        foreach (var obj in MenuList)
        {
            obj.Init();
        }
    }
    
    public void ActivatorMenu(MenuBase menu = null, float deley = 0)
    {
        foreach (var menuBase in MenuList)
        {
            if (menuBase.gameObject.activeSelf)
            {
                ScaleDown(menuBase , menu);
                return;
            }
        }

        queueMenuDic.Clear();
        
        if (menu != null)
        {
            queueMenuDic.Add(0, menu);
            ScaleBG(Vector3.one, deley);
            ScaleUp(menu, deley + 0.4f);
        }
        else
        {
            foreach (var menuBase in MenuList)
            {
                var pauseMenu = menuBase as PauseMenu;
                if (pauseMenu != null)
                {
                    queueMenuDic.Add(0, menuBase);
                    ScaleBG(Vector3.one, deley);
                    ScaleUp(pauseMenu, deley + 0.4f);
                    return;
                }
            }
        }
        
        
    }

    public void ScaleDown(MenuBase downMenu, MenuBase upMenu = null )
    {
        var downList = downMenu.AllObjectsRect;
        float delay = 0f;
        
        for (int j = 0; j < downList.Count; j++)
        {
            var obj = downList[j];

            if (j == downList.Count - 1 )
            {
                DOVirtual.DelayedCall(delay, () => obj.DOScale(Vector3.zero, 0.2f));
                DOVirtual.DelayedCall(delay + 0.2f, () => downMenu.ActiveOff());
                
                if (upMenu != null)
                {
                    ScaleUp(upMenu, delay);
                    var key = GetKey(downMenu);
                    queueMenuDic.Add(key+1, upMenu);
                    return;
                }
                Debug.Log(queueMenuDic.Count);
                if (queueMenuDic.Count > 1)
                {
                    var key = GetKey(downMenu);
                    queueMenuDic.Remove(key);
                    ScaleUp(queueMenuDic[key-1], delay);
                }
                else
                {
                    ScaleBG(Vector3.zero, delay);
                }

            }

            DOVirtual.DelayedCall(delay, () => obj.DOScale(Vector3.zero, 0.2f));
            delay += 0.1f;

        }
    }

    private int GetKey(MenuBase menu)
    {
        foreach (var obj in queueMenuDic)
        {
            if (obj.Value == menu)
            {
                return obj.Key;
            }
        }

        return 0;
    }

    public void ScaleUp(MenuBase upMenu = null ,float deley = 0)
    {
        var upList = upMenu.AllObjectsRect;
        
        float i = deley;
        
        DOVirtual.DelayedCall(i, () => upMenu.ActiveOn());

        for (int j = 0; j < upList.Count; j++)
        {
            var o = upList[j];
            o.DOScale(Vector3.zero, 0);

            DOVirtual.DelayedCall(i, () => o.DOScale(Vector3.one, 0.2f));
            i += 0.1f;
        }

    }
    
    private void ScaleBG(Vector3 scale, float deley = 0)
    {
        if (scale == Vector3.one)
        {
            menuBG.localScale = Vector3.zero;
            DOVirtual.DelayedCall(deley, () => menuBG.DOScale(scale, 0.4f));
        }
        else
        {
            menuBG.localScale = Vector3.one;
            DOVirtual.DelayedCall(deley, () => menuBG.DOScale(scale, 0.4f));
        }
    }

    public void BackButtonDown()
    {
        ActivatorMenu();
    }
    public void CloseAllMenu()
    {
        queueMenuDic.Clear();
        ActivatorMenu();
    }
}
