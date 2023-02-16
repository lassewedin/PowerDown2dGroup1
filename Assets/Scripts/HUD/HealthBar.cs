using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public float value;
    public RectTransform barTransform;
    
    void Update()
    {
        var delta = barTransform.sizeDelta;
        barTransform.anchorMax = new Vector2(1.0f, value);
        barTransform.sizeDelta = new Vector2(0,0);
    }
}
