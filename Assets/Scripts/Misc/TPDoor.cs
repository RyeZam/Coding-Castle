using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPDoor : MonoBehaviour
{
    public float reqEnemy = 0;
    //public GameObject player;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //player.GetComponent<Inventory>();
        if (reqEnemy == Inventory.enCount)
        {
            anim.SetBool("isOpen", true);
        }
    }
}
