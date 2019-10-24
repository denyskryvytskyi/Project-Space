using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// бесконечное вращение планет, станицй и т. д.
public class InfiniteRotation : MonoBehaviour
{
    [SerializeField]
    private float _speed; // скорость вращения

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * _speed * Time.deltaTime);
    }
}
