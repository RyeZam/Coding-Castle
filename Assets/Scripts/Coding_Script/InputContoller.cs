using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputContoller : MonoBehaviour
{
    private string input;
    public TextMeshProUGUI value;


    public void resetInput()
    {
        value.text = "Sample text";
    }

    public void ReadStringInput(string s)
    {
        input = s;
        Debug.Log(input);
        value.text = input;
    }


}
