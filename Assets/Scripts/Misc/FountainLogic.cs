using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainLogic : MonoBehaviour
{
    Animator anim;
    public string ReqType;
    public int ReqNum;
    private int num = 0;
    public int count=0;

    public AudioSource openSound;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pickup"))
        {
            string store = other.GetComponent<Jar>().typeNum;
            //Debug.Log(store);
            if (store == ReqType)
            {
                num += other.GetComponent<Jar>().value;

                if (num == ReqNum)
                {
                    //Open fountain
                    anim.SetBool("isOpen", true);
                    openSound.enabled = true;
                    //set a checkmark for a door opening
                    count++;
                    Inventory.fountain++;
                    //Debug.Log(count);
                    //FindObjectOfType<PuzzleOpen>().ftnOpen();
                }
            } 
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Pickup")){

            string store = other.GetComponent<Jar>().typeNum;

            if (store == ReqType)
            {
                num -= other.GetComponent<Jar>().value;
                count--;
                Inventory.fountain--;
            }
                
        }
    }
}
