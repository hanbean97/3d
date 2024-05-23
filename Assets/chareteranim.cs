using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chareteranim : MonoBehaviour
{
    Animator animator;
    [SerializeField] Transform lookobj;
    [SerializeField, Range(0.0f, 1.0f)] float lookrange;

    List<string>listDance = new List<string>();
    bool dodance;
    bool doDance
    {
        get
        {
            return true;
        }
        set
        {
            dodance = value;
            if(value == true)
            {
                if (Cursor.lockState == CursorLockMode.Locked)
                {
                    Cursor.lockState = CursorLockMode.None;
                }
            }
            else
            {
                if (Cursor.lockState == CursorLockMode.Locked)
                {
                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        initAniDance();
    }
    private void initAniDance()
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        int count = clips.Length;
        for (int i = 0; i < count; i++)
        {
            if( clips[i].name.Contains("Dance_"))
            {
                listDance.Add(clips[i].name);
            }
        }
    }

    void Start()
    {
        
    }
    void Update()
    {
        animator.SetFloat("speedHorizontal",Input.GetAxisRaw("Vertical"));
        CheckDance();
    }
    private void OnAnimatorIK(int layerIndex)
    {
        if(lookobj != null)
        {
            animator.SetLookAtPosition(lookobj.position);
            animator.SetLookAtWeight(lookrange);
        }
       // animator.GetCurrentAnimatorStateInfo(0).
    }

    private void CheckDance()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
               
            }
            //animator.Play(listDance[0]);
            animator.CrossFade(listDance[0],0.5f);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
           // animator.Play(listDance[1]);
            animator.CrossFade(listDance[1], 0.5f);
        }
    }
}
