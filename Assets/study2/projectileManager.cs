using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileManager : MonoBehaviour
{
    [SerializeField] GameObject objCursor;
    Camera cammain;
    void Start()
    {
        cammain = Camera.main;
    }

    void Update()
    {
        checkMOuse();
    }
    private void checkMOuse()
    {
        Ray ray = cammain.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out RaycastHit hit, 100, LayerMask.GetMask("Ground")))
        {
            objCursor.SetActive(true);
            objCursor.transform.position = hit.point+ Vector3.up ;
        }
        else
        {
            objCursor.SetActive(false);
        }
    }
}
