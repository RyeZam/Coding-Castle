using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step5 : MonoBehaviour
{
    public static bool StepFive;

    // Start is called before the first frame update
    void Start()
    {
        StepFive = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("Player")) || (other.CompareTag("Pickup")))
        {
            StepFive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if ((other.CompareTag("Player")) || (other.CompareTag("Pickup")))
        {
            StepFive = false;
        }
    }
}
