using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject[] espinhos;
    public GameObject[] fogo;
    

    public void DestroyEspinhos()
    {
        for(int i = 0; i<espinhos.Length; i++)
        {
            Destroy(espinhos[i]);
        }
    }

    public void DestroyFogo()
    {
        for(int i = 0; i<fogo.Length; i++)
        {
            Destroy(fogo[i]);
        }
    }
    
}
