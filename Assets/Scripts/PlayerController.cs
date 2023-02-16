using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Vector2 speed; // horizontal, vertical
    public Vector4 limits; // left, right, bottom top

    public Transform bobbingTransform;

    public float bobbingTime;

    public PlayerGun gun;

    public SpriteRenderer grapeRenderer;
    public Sprite normalGrapeNormal;
    public Sprite shootGrapeNormal;
    public Sprite normalGrapeRaisin;
    public Sprite shootGrapeRaisin;
    public Sprite hurtGrape;
    public Sprite raisinGrape; // die

    public Vector2 startPosition;

    [HideInInspector]
    public bool isDead;
    
    private bool isRaisin;

    public void RespawnPlayer() {
        transform.position = startPosition;
        grapeRenderer.sprite = normalGrapeNormal;
        isDead = false;
        isRaisin = false;
    }

    public void Die() {
        grapeRenderer.sprite = raisinGrape;
        isDead = true;
    }

    // Update is called once per frame
    private void Update() {
        bobbingTransform.localPosition = new Vector3(0f, Mathf.Sin(bobbingTime * 30f) * 0.1f, 0f);

        hurtCooldown -= Time.deltaTime;
    }

    public void Hurt() {
        hurtCooldown = 1f;
    }
    private float hurtCooldown;

    public void MakeRaisin() {
        isRaisin = true;
    }

    private void FixedUpdate() {
        Vector2 deltaPosition = new Vector2();
        bool didMove = false;

        if (Input.GetKey("x")) {
            isRaisin = true;
        }

        if (Input.GetKey("r")) {
            //RespawnPlayer();
        }

        if (isDead) {
            return;
        }

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

        if (hurtCooldown > 0) {

        } else {
            if (gun.hasShootFace) {
                if (isRaisin) {
                    grapeRenderer.sprite = shootGrapeRaisin;
                }
                else {
                    grapeRenderer.sprite = shootGrapeNormal;
                }
            }
            else {
                if (isRaisin) {
                    grapeRenderer.sprite = normalGrapeRaisin;
                }
                else {
                    grapeRenderer.sprite = normalGrapeNormal;
                }
            }
        }
    }
}
