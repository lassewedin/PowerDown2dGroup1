using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Rigidbody2D body;

    private void Start() {
        
    }

    // Update is called once per frame
    private void Update() {
        
    }

    private void FixedUpdate() {
        Vector2 force = new Vector2(0.1f, 0f);
        body.AddForceAtPosition(force, transform.position, ForceMode2D.Impulse);
    }
}
