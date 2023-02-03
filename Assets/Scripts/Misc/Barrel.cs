using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Smash()
    {
        FindObjectOfType<AudioManager>().Play("Barrel Explosion");
        anim.SetBool("Smashed", true);
    }

    private void BarrelDestroy()
    {
        Destroy(gameObject);
    }
}
