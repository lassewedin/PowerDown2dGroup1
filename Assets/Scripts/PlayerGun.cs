using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour {

    public GunProjectile projectileTemplate;
    public Transform worldTransform;

    private Ray cameraRay;                // The ray that is cast from the camera to the mouse position
    private RaycastHit cameraRayHit;    // The object that the ray $$anonymous$$ts


    private float aimAngle;

    void Update() {
        cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector2 deltaPosition = new Vector2(cameraRay.origin.x, cameraRay.origin.y) - new Vector2(transform.position.x, transform.position.y);

        float angle = Mathf.Atan2(deltaPosition.x, deltaPosition.y) * Mathf.Rad2Deg;
        angle = -angle + 90f;
        //Debug.Log("Angle: " + angle);
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (Input.GetMouseButtonDown(0)) {
            Shoot(angle);
        }
    }

    public void Shoot(float angle) {
        GunProjectile proj = Object.Instantiate(projectileTemplate, worldTransform);
        projectileTemplate.gameObject.SetActive(false);
        proj.direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        proj.transform.position = transform.position + (Vector3)proj.direction;
        proj.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        proj.gameObject.SetActive(true);
        proj.isTemplate = false;
    }
}
