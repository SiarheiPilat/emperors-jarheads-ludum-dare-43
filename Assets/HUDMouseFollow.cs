using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDMouseFollow : MonoBehaviour
{
    private RectTransform rectTransform;
    private float pivotX, pivotY;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        transform.position = Input.mousePosition;
        TrackPosition();
        rectTransform.pivot = new Vector2(pivotX, pivotY);
    }

    void TrackPosition()
    {
        if (rectTransform.anchoredPosition.x < 0)
        {
            pivotX = 0.0f;
        }
        if (rectTransform.anchoredPosition.x > 0)
        {
            pivotX = 1.0f;
        }
        if (rectTransform.anchoredPosition.y < 0)
        {
            pivotY = 0.0f;
        }
        if (rectTransform.anchoredPosition.y > 0)
        {
            pivotY = 1.0f;
        }
    }
}
