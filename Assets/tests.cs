using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tests : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = Instantiate(mr.material);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
