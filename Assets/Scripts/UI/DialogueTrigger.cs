using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public SampleCodes samples;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<PlayerMove>().LockMovement();
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        FindObjectOfType<DManager>().StartDialogue(samples);
    }
}
