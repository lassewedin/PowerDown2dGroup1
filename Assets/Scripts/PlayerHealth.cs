using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [HideInInspector] public override int health { 
        get { return base.m_health; }
        set { m_health = value; HUD.SetHealth(m_health); }
    }

    private bool belowHalfHP = false;
    public override void Damage(int amount)
    {
        var controller = gameObject.GetComponent<PlayerController>();
        if (health - amount < maxHealth / 2 && !belowHalfHP)
        {
            belowHalfHP = true;
            controller.MakeRaisin();
            
        } else if (health - amount >= maxHealth / 2)
        {
            controller.Hurt();
        }
        
        
        base.Damage(amount);
    }
}
