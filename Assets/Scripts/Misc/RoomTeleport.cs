using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;

            if (currentTeleporter != null)
            {
                FindObjectOfType<AudioManager>().Play("Teleport");
                transform.position = currentTeleporter.GetComponent<Teleport>().GetDestination().position;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }

}
