using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MAG.Game;

public class Hazard : MonoBehaviour, ITouchable
{
    [SerializeField] private int damage;
    public int value { get => damage; set => damage = value; }

    public void OnTouch()
    {
        // Make an FX of damage
    }
}
