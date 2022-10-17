using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private bool isCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Collect()
    {
        if (isCollected)
            return false;

        isCollected = true;
        Destroy(gameObject);
        return true;
    }

}
