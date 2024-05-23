using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tests : MonoBehaviour
{
    void Start()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = Instantiate(mr.material);
       // SceneManager.
    }

    void Update()
    {
        
    }

  
}
