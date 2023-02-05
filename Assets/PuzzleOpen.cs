using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleOpen : MonoBehaviour
{
    public int reqFtn;
    //public int ftncount = 0;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (reqFtn == Inventory.fountain)
        {
            animator.SetBool("isOpen", true);
        }
    }

    /*public void ftnOpen()
    {
        ftncount = GetComponent<FountainLogic>().count;

        if (reqFtn == ftncount)
        {
            animator.SetBool("isOpen", true);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<LevelClear>().ScoreComputation();
        }
    }

    public void OnNext()
    {
        FindObjectOfType<SceneMove>().LoadNextScene();
    }
}
