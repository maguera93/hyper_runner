using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MAG.Game
{
    public interface ITouchable
    {
        int value { get; set; }
        void OnTouch();
    }
}
