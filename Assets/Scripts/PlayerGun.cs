using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour {

    // Update is called once per frame

    private Ray cameraRay;                // The ray that is cast from the camera to the mouse position
    private RaycastHit cameraRayHit;    // The object that the ray $$anonymous$$ts


    void Update() {
        cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector2 deltaPosition = new Vector2(cameraRay.origin.x, cameraRay.origin.y) - new Vector2(transform.position.x, transform.position.y);

        float angle = Mathf.Atan2(deltaPosition.x, deltaPosition.y) * Mathf.Rad2Deg;
        angle = -angle + 90f;
        //Debug.Log("Angle: " + angle);
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
