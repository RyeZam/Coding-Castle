using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stepped : MonoBehaviour
{
    public static bool Step;

    // Start is called before the first frame update
    void Start()
    {
        Step = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if((other.CompareTag("Player")) || (other.CompareTag("Pickup"))){
            Step = true;
        }
    }
}
