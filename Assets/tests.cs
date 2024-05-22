using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tests : MonoBehaviour
{
    void Start()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = Instantiate(mr.material);


    }

    void Update()
    {
        
    }

  
}
