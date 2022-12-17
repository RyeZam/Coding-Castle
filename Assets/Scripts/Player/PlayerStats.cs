using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    Scene currentScene;
    public float currentHitpoint;
    public string currentLevel;
    //public 

    public void SaveStats()
    {
        currentScene = SceneManager.GetActiveScene();
        currentLevel = currentScene.name;
    }
}
