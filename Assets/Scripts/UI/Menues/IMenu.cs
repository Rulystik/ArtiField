using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Menues
{
    public interface IMenu
    {
        public List<RectTransform> AllRects { get ; set; }
        float Open(float deley = 0f);
        float Close(float del = 0f);
    }
}