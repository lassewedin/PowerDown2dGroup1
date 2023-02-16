using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [HideInInspector] public override int health { 
        get { return base.m_health; }
        set { m_health = value; HUD.SetHealth(m_health); }
    }
    
    public override void Damage(int amount)
    {
        gameObject.GetComponent<PlayerController>().Hurt();
        base.Damage(amount);
    }
}
