using UnityEngine;

public class AI_Movement : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    void Update()
    {
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
    }
}
