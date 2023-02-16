using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavyWave : MonoBehaviour
{
    public Image image;
    public float speed;
    
    private Material _material;
    private float _offset;

    void Start()
    {
        _material = image.material = new Material(image.material);
    }

    void Update()
    {
        _offset += Time.deltaTime * speed;
        _material.mainTextureOffset = new Vector2(_offset, 0);
    }
}
