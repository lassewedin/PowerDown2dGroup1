using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunProjectile : MonoBehaviour {

    [HideInInspector]
    public bool isTemplate = true;

    [HideInInspector]
    public Vector2 direction;

    private float timeAlive = 0f;
    private float timeToLive = 1f;

    public float speed;

    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        //timeAlive += Time.deltaTime;
        //if (timeAlive > timeToLive && !isTemplate) {
        //    Destroy(gameObject);
        //}
    }

    private void FixedUpdate() {
        Vector2 deltaPosition = direction.normalized * speed * Time.fixedDeltaTime;
        transform.position = new Vector3(transform.position.x + deltaPosition.x, transform.position.y + deltaPosition.y, 0f); // (Vector3)(transform.position + (Vector3)deltaPosition);
    }
}
