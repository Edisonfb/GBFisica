using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilador : MonoBehaviour
{
    public float rotate;
    void Update()
    {
        transform.Rotate(Vector3.up * rotate);
    }
}
