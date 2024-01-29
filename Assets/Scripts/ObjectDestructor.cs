using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestructor : MonoBehaviour
{
    public float destructionDelay = 5.0f;

    void Start()
    {
        Destroy(gameObject, destructionDelay);
    }
}
