using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [HideInInspector] public override int health { 
        get { return base.m_health; }
        set { m_health = value; HUD.SetHealth(m_health); }
    }
}
