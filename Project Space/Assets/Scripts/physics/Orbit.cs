using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform orbitObject; // то, вокруг чего вращается, в данном случае планета
    public float speed; // скорость вращения

    // Update is called once per frame
    void Update()
    {
        OrbitAround();
    }

    void OrbitAround()
    {
        transform.RotateAround(orbitObject.transform.position, Vector3.back, speed * Time.deltaTime);
    }
}
