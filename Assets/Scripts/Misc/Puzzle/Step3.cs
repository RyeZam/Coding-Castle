using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step3 : MonoBehaviour
{
    public static bool StepThree;

    // Start is called before the first frame update
    void Start()
    {
        StepThree = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("Player")) || (other.CompareTag("Pickup")))
        {
            StepThree = true;
        }
    }
}
