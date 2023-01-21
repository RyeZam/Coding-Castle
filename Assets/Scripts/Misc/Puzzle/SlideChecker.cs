using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideChecker : MonoBehaviour
{
    public static bool Step2;

    // Start is called before the first frame update
    void Start()
    {
        Step2 = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("Player")) || (other.CompareTag("Pickup")))
        {
            Step2 = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if ((other.CompareTag("Player")) || (other.CompareTag("Pickup")))
        {
            Step2 = false;
        }
    }
}
