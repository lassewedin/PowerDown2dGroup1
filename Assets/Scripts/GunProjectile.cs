using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunProjectile : MonoBehaviour
{

    public int damage = 50;
    [HideInInspector]
    public bool isTemplate = true;

    [HideInInspector]
    public Vector2 direction;

    private float timeAlive = 0f;
    private float timeToLive = 2f;

    public float speed;
    public GameObject spawner;

    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        timeAlive += Time.deltaTime;
        if (timeAlive > timeToLive && !isTemplate) {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate() {
        Vector2 deltaPosition = direction.normalized * speed * Time.fixedDeltaTime * PlayerAttributes.projectileSpeed;
        transform.position = new Vector3(transform.position.x + deltaPosition.x, transform.position.y + deltaPosition.y, 0f); // (Vector3)(transform.position + (Vector3)deltaPosition);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == spawner) return;
        
        var health = col.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.Damage(damage);
        }

        if (!isTemplate) {
            Destroy(gameObject);
        }

    }
}
