using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step4 : MonoBehaviour
{
    public static bool StepFour;

    // Start is called before the first frame update
    void Start()
    {
        StepFour = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("Player")) || (other.CompareTag("Pickup")))
        {
            StepFour = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if ((other.CompareTag("Player")) || (other.CompareTag("Pickup")))
        {
            StepFour = false;
        }
    }
}
