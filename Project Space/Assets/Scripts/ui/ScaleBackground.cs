using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBackground : MonoBehaviour
{
    private Vector2 bottomLeft;
    private Vector2 topRight;
   
    void Update()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(Vector2.zero);
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        var height = topRight.y - bottomLeft.y;
        var width = topRight.x - bottomLeft.x;

        transform.localScale = new Vector3(width/19.20f, height/10.80f, 1f);
    }
}
