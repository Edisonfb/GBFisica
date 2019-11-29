using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagono : MonoBehaviour
{
    public float rotation;
   
    void Update()
    {
        transform.Rotate(Vector3.right * rotation * Time.deltaTime);
    }

    
}
