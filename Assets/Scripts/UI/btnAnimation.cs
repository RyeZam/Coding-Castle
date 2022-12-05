using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnAnimation : MonoBehaviour
{
    public GameObject myBtn;

    private void Start()
    {
        //myBtn = GetComponent<GameObject>();
    }

    public void Pressed()
    {
        myBtn.SetActive(true);
    }

    public void End()
    {
        FindObjectOfType<DManager>().EndDialogue();
        myBtn.SetActive(false);
    }
}
