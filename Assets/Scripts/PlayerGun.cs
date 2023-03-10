using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour {

    public PlayerController playerController;
    public GunProjectile projectileTemplate;
    public Transform worldTransform;
    public Transform recoilTransform;
    public SpriteRenderer gunRenderer;
    public Sprite gunUnloaded;
    public Sprite gunLoaded;

    public Vector2 projectileOffset;

    [HideInInspector]
    public bool hasShootFace;

    private Ray cameraRay;                // The ray that is cast from the camera to the mouse position
    private RaycastHit cameraRayHit;    // The object that the ray $$anonymous$$ts


    private float fireCoolDown;
    private float shootFaceCoolDownn;

    void Update() {
        cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector2 deltaPosition = new Vector2(cameraRay.origin.x, cameraRay.origin.y) - new Vector2(transform.position.x, transform.position.y);
        gunRenderer.flipY = deltaPosition.x < 0;

        float angle = Mathf.Atan2(deltaPosition.x, deltaPosition.y) * Mathf.Rad2Deg;
        angle = -angle + 90f;
        //Debug.Log("Angle: " + angle);
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (playerController.isDead) {
            return;
        }

        //Semi
        if (PlayerAttributes.ammo == Ammo.semiShot && Input.GetMouseButtonDown(0) && fireCoolDown < 0) {
            Shoot(angle);
            recoil = 0.2f;
            fireCoolDown = 0.3f * PlayerAttributes.fireCoolDown;
            shootFaceCoolDownn = 0.3f;
        }

        //Auto
        if (PlayerAttributes.ammo == Ammo.autoShot && Input.GetMouseButton(0) && fireCoolDown < 0) {
            Shoot(angle);
            recoil = 0.2f;
            fireCoolDown = 0.15f * PlayerAttributes.fireCoolDown;
            shootFaceCoolDownn = 0.3f;
        }

        recoil -= Time.deltaTime;
        fireCoolDown -= Time.deltaTime;
        shootFaceCoolDownn -= Time.deltaTime;
        
        if (fireCoolDown > 0) {
            gunRenderer.sprite = gunUnloaded;
        } else {
            gunRenderer.sprite = gunLoaded;
        }
        

        recoil = Mathf.Max(0f, recoil);
        recoilTransform.localPosition = new Vector3(-recoil, 0f, 0f);

        hasShootFace = shootFaceCoolDownn > 0;
    }

    private float recoil = 0f;

    public void Shoot(float angle) {
        GunProjectile proj = Object.Instantiate(projectileTemplate, worldTransform);
        projectileTemplate.gameObject.SetActive(false);
        proj.spawner = transform.root.gameObject;
        proj.direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        proj.transform.position = transform.position + (Vector3)projectileOffset + (Vector3)proj.direction * 2f;
        proj.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        proj.gameObject.SetActive(true);
        proj.isTemplate = false;
    }
}