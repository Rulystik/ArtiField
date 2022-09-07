using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace UI.Menues
{
    public abstract class BaseMenu : MonoBehaviour, IMenu
    {
        public List<RectTransform> AllChildrenRect { get ;}

        protected void GetChildrenRect()
        {
            foreach (Transform obj in transform)
            {
                AllChildrenRect.Add(obj.GetComponent<RectTransform>());
            }
        }

        public float Open(float del = 0f)
        {
            float deley = del;

            foreach (var rectTransform in AllChildrenRect)
            {
                DOVirtual.DelayedCall(del + deley, () => rectTransform.DOScale(Vector3.one, 0.2f));
                deley += 0.2f;
            }

            return deley;
        }

        public float Close()
        {
            float deley = 0f;
            foreach (var rectTransform in AllChildrenRect)
            {
                DOVirtual.DelayedCall(deley, () => rectTransform.DOScale(Vector3.zero, 0.2f));
                deley += 0.2f;
            }

            return deley;
        }
        protected void SetScaleZero()
        {
            foreach (var rectTransform in AllChildrenRect)
            {
                rectTransform.DOScale(Vector3.zero, 0);
            }
        }
    }
}
