using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chareteranim : MonoBehaviour
{
    Animator animator;
    [SerializeField] Transform lookobj;
    [SerializeField, Range(0.0f, 1.0f)] float lookrange;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        animator.SetFloat("speedHorizontal",Input.GetAxisRaw("Vertical"));
    }
    private void OnAnimatorIK(int layerIndex)
    {
        if(lookobj != null)
        {
            animator.SetLookAtPosition(lookobj.position);
            animator.SetLookAtWeight(lookrange);
        }
    }
}
