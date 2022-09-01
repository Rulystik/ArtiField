using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace UI.Menues
{
    public abstract class BaseMenu : MonoBehaviour, IMenu
    {
        public List<RectTransform> AllChildrenRect { get ;} = new List<RectTransform>();
        public Action AnimationCallBAck;

        public abstract void Init();

        public void ActiveOn()
        {
            gameObject.SetActive(true);
        }

        public void ActiveOff()
        {
            gameObject.SetActive(false);
        }
        public void GetChildrenRect()
        {
            foreach (Transform obj in transform)
            {
                AllChildrenRect.Add(obj.GetComponent<RectTransform>());
            }
        }

        public float Open(float del = 0f)
        {
            float deley = 0;
            ActiveOn();
            SetScale(0);

            foreach (var rectTransform in AllChildrenRect)
            {
                DOVirtual.DelayedCall(del + deley, () => rectTransform.DOScale(Vector3.one, 0.2f));
                deley += 0.2f;
            }

            return deley;
        }

        public void Close()
        {
            foreach (var rectTransform in AllChildrenRect)
            {
                rectTransform.DOScale(Vector3.zero, 0.2f);
            }
        }
        private void SetScale(int scale)
        {
            foreach (var rectTransform in AllChildrenRect)
            {
                rectTransform.DOScale(Vector3.zero, scale);
            }
        }
    }
}
