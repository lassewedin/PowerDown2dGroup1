using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
  [HideInInspector] public int health { 
        get { return m_health; }
        set { m_health = value; HUD.SetHealth(m_health); }
    }
  private int m_health;

  public int maxHealth = 100;
  
  public bool isDead
  {
    get { return health <= 0; }
  }

  public void ResetHealth()
  {
    health = maxHealth;
  }

  public void Heal(int amount)
  {
    health = health + amount > maxHealth ? maxHealth : health + amount;
  }
  
  public void Damage(int amount)
  {
    health = health - amount  < 0 ? 0 : health - amount;
  }
}
