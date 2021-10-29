using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MAG.Utils;

public class PlayerModel : IModel
{
    
    public event Action<PlayerModel, int> getDamage = delegate { };
    public event Action<PlayerModel> die = delegate { };


    public int Soldiers { get; private set; }
    public float Speed { get; private set; }

    public PlayerModel(PlayerConfig config)
    {
        Speed = config.Speed;
        Soldiers = config.Soldiers;
    }

    public void AddSoldiers(int soldiers)
    {
        Soldiers += soldiers;
    }

    public void GetDamage(int damage)
    {
        Soldiers -= damage;
        getDamage.Invoke(this, damage);
    }
}
