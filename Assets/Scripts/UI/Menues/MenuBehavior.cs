using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace UI.Menues
{
    public class MenuBehavior
    {
        private List<BaseMenu> MenuList { get;}
        private RectTransform menuBG;

        private Dictionary<int, BaseMenu> queueMenuDic;
    
        public  MenuBehavior(List<BaseMenu> list)
        {
            queueMenuDic = new Dictionary<int, BaseMenu>();
            MenuList = list;
            menuListInit();
            menuBG = MenuList.FirstOrDefault().transform.parent.GetComponent<RectTransform>();
            menuBG.gameObject.SetActive(true);
        }
        private void menuListInit()
        {
            foreach (var obj in MenuList)
            {
                obj.Init();
            }
        }
    
        public void ActivatorMenu(BaseMenu menu = null, float deley = 0)
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
                ScaleUpOrDownBG(Vector3.one, deley);
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
                        ScaleUpOrDownBG(Vector3.one, deley);
                        ScaleUp(pauseMenu, deley + 0.4f);
                        return;
                    }
                }
            }
        
        
        }

        public void ScaleDown(BaseMenu downMenu, BaseMenu upMenu = null )
        {
            var downList = downMenu.AllChildrenRect;
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
                    if (queueMenuDic.Count > 1)
                    {
                        var key = GetKey(downMenu);
                        queueMenuDic.Remove(key);
                        ScaleUp(queueMenuDic[key-1], delay);
                    }
                    else
                    {
                        ScaleUpOrDownBG(Vector3.zero, delay);
                    }
                }

                DOVirtual.DelayedCall(delay, () => obj.DOScale(Vector3.zero, 0.2f));
                delay += 0.1f;

            }
        }

        private int GetKey(BaseMenu menu)
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

        public void ScaleUp(BaseMenu upMenu = null ,float deley = 0)
        {
            var upList = upMenu.AllChildrenRect;
        
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
    
        private void ScaleUpOrDownBG(Vector3 scale, float deley = 0)
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
        public void CloseAllMenu()
        {
            queueMenuDic.Clear();
            ActivatorMenu();
        }
    }
}
