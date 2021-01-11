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

        transform.localScale = new Vector3(width / 16.0f, height / 9.0f, 1f);
        Debug.Log(gameObject.name);
    }
}