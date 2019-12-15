using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Vector3 offset;

    void Update()
    {
        transform.position = player.position + offset;
    }
}
