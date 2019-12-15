using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform orbitObject; // то, вокруг чего вращается, в данном случае планета
    public float speed; // скорость вращения

    void Update()
    {
        OrbitAround();
    }

    void OrbitAround()
    {
        transform.RotateAround(orbitObject.transform.position, Vector3.back, speed * Time.deltaTime);
    }
}
