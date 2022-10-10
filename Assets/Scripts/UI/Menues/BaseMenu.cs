using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


namespace UI.Menues
{
    public abstract class BaseMenu : MonoBehaviour
    {
        public List<RectTransform> AllRects { get ; set; }

        protected void GetChildrenRect()
        {
            AllRects = new List<RectTransform>();
            foreach (Transform obj in transform)
            {
                AllRects.Add(obj.GetComponent<RectTransform>());
            }
        }
        

        public virtual float Open(float del = 0f)
        {
            float deley = del;

            foreach (var rectTransform in AllRects)
            {
                DOVirtual.DelayedCall(deley, () => rectTransform.DOScale(Vector3.one, 0.2f));
                deley += 0.1f;
            }

            return deley;
        }

        public virtual float Close(float del = 0f)
        {
            float deley = del;
            foreach (var rectTransform in AllRects)
            {
                DOVirtual.DelayedCall(deley, () => rectTransform.DOScale(Vector3.zero, 0.2f));
                deley += 0.1f;
            }

            return deley;
        }
        protected void SetScaleZero()
        {
            foreach (var rectTransform in AllRects)
            {
                rectTransform.DOScale(0, 0);
            }
        }
    }
}
