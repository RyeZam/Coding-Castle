using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    //public float reqEnemy = 0;
    //public int reqCoin = 0;
    public int reqChest;

    //public string nextLevel = "Level 2";
    public int levelToUnlock = 1;
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
        if (reqChest==Inventory.chest)
        {
            anim.SetBool("isOpen", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<LevelClear>().ScoreComputation();

            Inventory.lvl = levelToUnlock;
        }
    }

    public void OnNext()
    {
        FindObjectOfType<SceneMove>().LoadNextScene();
    }
}
