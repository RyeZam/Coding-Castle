using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    Animator anim;

    //public GameObject textBox;
    //public TextMeshProUGUI dialogue;
    public static bool opened;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        opened = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Open()
    {
        opened = true;
        Inventory.chest++;
        //PlayerHealth health = GetComponent<PlayerHealth>();
        //health.playerHealth += 100;
        Store.lvl++;
        anim.SetBool("isOpen", true);
    }

}
