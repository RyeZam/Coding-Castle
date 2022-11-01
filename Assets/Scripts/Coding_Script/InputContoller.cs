using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputContoller : MonoBehaviour
{

    public TMP_InputField mainInputField;

    public void Activate()
    {
        mainInputField.ActivateInputField();
    }

    public void Deselect()
    {
        mainInputField.DeactivateInputField();
        Debug.Log("Got Here");
    }

}
