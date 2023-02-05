using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainLogic : MonoBehaviour
{
    Animator anim;
    public string ReqType;
    public int ReqNum;
    private int num = 0;
    public int count=1;

    bool turnOn = false;
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

            if (store == ReqType)
            {
                num += other.GetComponent<Jar>().value;
                //Debug.Log(num);
                if (num == ReqNum) turnOn = true;
                Check();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Pickup")){

            string storeN = other.GetComponent<Jar>().typeNum;

            if (storeN == ReqType)
            {
                num--;
                //count--;
                //Debug.Log(num);
                //turnOn = false;
                Check();
            }   
        }
    }

    private void Check()
    {
        if (num != ReqNum && turnOn)
        {
            anim.SetBool("isOpen", false);
            openSound.enabled = false;
            //count--;
            Inventory.fountain--;
            Debug.Log(Inventory.fountain);
        }
        else if (num == ReqNum && turnOn)
        {
            //Open fountain
            anim.SetBool("isOpen", true);
            openSound.enabled = true;
            //set a checkmark for a door opening
            //count++;
            Inventory.fountain++;
            Debug.Log(Inventory.fountain);
            //FindObjectOfType<PuzzleOpen>().ftnOpen();
        }
    }
}
