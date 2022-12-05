using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputContoller : MonoBehaviour
{

    public TMP_InputField mainInputField;
    public Button yourButton;

    private void Start()
    {
        //yourButton = GetComponent<Button>();
    }

    /*public void Activate()
    {
        mainInputField.ActivateInputField();
    }

    public void Deselect()
    {
        mainInputField.DeactivateInputField();
        Debug.Log("Got Here");
    }*/

    public void Disables()
    {
        BattleSystem yes = FindObjectOfType<BattleSystem>();
        if (yes.yes == true)
        {
            mainInputField.interactable = false;
            yourButton.interactable = false;
        }
    }


}
