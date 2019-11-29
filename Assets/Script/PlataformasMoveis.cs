using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformasMoveis : MonoBehaviour
{
    public float direction;
    public float velocity;

    
    void Update()
    {
        transform.position += Vector3.forward * direction * velocity * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Limite")
        {
            direction *= -1;
            Debug.Log("colidiu com o limite");
        }
    }
}
