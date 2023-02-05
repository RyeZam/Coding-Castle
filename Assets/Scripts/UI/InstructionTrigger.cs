using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionTrigger : MonoBehaviour
{
    public SampleCodes samples;


    public void TriggerDialogue()
    {
        FindObjectOfType<DManager>().StartDialogue(samples);
    }
}
