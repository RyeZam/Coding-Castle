using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2 : MonoBehaviour
{
    public static bool check = false;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Step3.StepThree == true && SlideChecker.Step2 == true) {
            anim.SetBool("isOpen", true);
        } 
    }
}
