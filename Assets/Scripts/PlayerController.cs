using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Vector2 speed; // horizontal, vertical
    public Vector4 limits; // left, right, bottom top

    public Transform bobbingTransform;

    public float bobbingTime;

    // Update is called once per frame
    private void Update() {
        bobbingTransform.localPosition = new Vector3(0f, Mathf.Sin(bobbingTime * 30f) * 0.1f, 0f);
    }

    private void FixedUpdate() {
        Vector2 deltaPosition = new Vector2();
        bool didMove = false;

        if (Input.GetKey("d")) {
            deltaPosition.x += speed.x * Time.fixedDeltaTime;
            didMove = true;
        }
        if (Input.GetKey("a")) {
            deltaPosition.x -= speed.x * Time.fixedDeltaTime;
            didMove = true;
        }
        if (Input.GetKey("w")) {
            deltaPosition.y += speed.x * Time.fixedDeltaTime;
            didMove = true;
        }
        if (Input.GetKey("s")) {
            deltaPosition.y -= speed.x * Time.fixedDeltaTime;
            didMove = true;
        }

        if (didMove) {
            bobbingTime += Time.deltaTime;
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x + deltaPosition.x, limits.x, limits.y), Mathf.Clamp(transform.position.y + deltaPosition.y, limits.z, limits.w), transform.position.z);

        
    }
}
