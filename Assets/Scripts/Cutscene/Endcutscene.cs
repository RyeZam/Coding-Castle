using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Endcutscene : MonoBehaviour
{

    void OnEnable()
    {
        SceneManager.LoadScene("EndCredits", LoadSceneMode.Single);
    }
   
}
