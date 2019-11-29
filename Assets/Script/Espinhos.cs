using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinhos : MonoBehaviour
{
    public float timer;
    public float force;
    public float tempo;
    public Rigidbody rb;
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer > tempo)
        {
            rb.AddForce(Vector3.down * force, ForceMode.Acceleration);
            timer = 0;
        }
    }
}
