using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPunch : EnemyAttack
{
    public float shootCooldown = 1;
    private float fireCoolDown;
    public override void Attack(Vector2 direction)
    {
        if (fireCoolDown < 0) {
            Punch(direction);
            fireCoolDown =shootCooldown;
        }
        
        fireCoolDown -= Time.deltaTime;
    }

    void Punch(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);

        // If it hits something...
        if (hit.collider != null)
        {
            int i = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.Damage(10);
        }
    }
}
