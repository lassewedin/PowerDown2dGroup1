using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
 public virtual int health { 
    get { return m_health; }
    set { m_health = value; }
  }
  public int m_health = 100;

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
