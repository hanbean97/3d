using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileManager : MonoBehaviour
{
    [SerializeField] GameObject objCursor;
    Camera cammain;
    [SerializeField] Transform trscannon;
    [SerializeField] GameObject fab;
    [SerializeField] Transform trsMuzzle;
    [SerializeField] float time =2;
    [SerializeField] float raito =0.5f;
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
            objCursor.transform.position = hit.point+ Vector3.up *0.00001f;
            Vector3 vo = caluateVelocity(hit.point);
            trscannon.rotation = Quaternion.LookRotation(vo);
            
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameObject go = Instantiate(fab,trsMuzzle.transform.position,Quaternion.identity);
                Rigidbody rb = go.GetComponent<Rigidbody>();
                rb.velocity = vo;

            }
        }
        else
        {
            objCursor.SetActive(false);
        }
    }

    private Vector3 caluateVelocity(Vector3 _target)
    {
        Vector3 distance = _target - trscannon.position;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0;
        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude;
        float Vxz = Sxz / time;
        float Vy = Sy /time + raito * Mathf.Abs(Physics.gravity.y) * time;
        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;
         
        return result;
    }
}
