using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Vector2 speed; // horizontal, vertical
    public Vector4 limits; // left, right, bottom top

    // Update is called once per frame
    private void Update() {
        
    }

    private void FixedUpdate() {
        Vector2 deltaPosition = new Vector2();

        if (Input.GetKey("d")) {
            deltaPosition.x += speed.x * Time.fixedDeltaTime; 
        }
        if (Input.GetKey("a")) {
            deltaPosition.x -= speed.x * Time.fixedDeltaTime;
        }
        if (Input.GetKey("w")) {
            deltaPosition.y += speed.x * Time.fixedDeltaTime;
        }
        if (Input.GetKey("s")) {
            deltaPosition.y -= speed.x * Time.fixedDeltaTime;
        }


        transform.position = new Vector3(Mathf.Clamp(transform.position.x + deltaPosition.x, limits.x, limits.y), Mathf.Clamp(transform.position.y + deltaPosition.y, limits.z, limits.w), transform.position.z);

        
    }
}
