using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : EnemyAttack
{
    public GunProjectile projectileTemplate;
    
    private Ray cameraRay;                // The ray that is cast from the camera to the mouse position
    private RaycastHit cameraRayHit;    // The object that the ray $$anonymous$$ts

    public float shootCooldown = 1;
    private float fireCoolDown;
    public override void Attack(Vector2 direction)
    {
        if (fireCoolDown < 0) {
            Shoot(direction);
            fireCoolDown =shootCooldown;
        }
        
        fireCoolDown -= Time.deltaTime;
    }



    public void Shoot(Vector2 direction) {
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        angle =  -angle + 90f;
        GunProjectile proj = Object.Instantiate(projectileTemplate);
        projectileTemplate.gameObject.SetActive(false);
        projectileTemplate.spawner = gameObject;
        proj.direction = direction;
        proj.transform.position = transform.position + (Vector3)proj.direction;
        proj.transform.rotation = Quaternion.Euler(0f, 0f, -angle);
        proj.gameObject.SetActive(true);
        proj.isTemplate = false;
    }
}
