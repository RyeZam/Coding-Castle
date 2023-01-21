using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Store: MonoBehaviour
{
    public static int lvlIndex, lvl;
    public static float currentHP;

    public int Currentlvl, LevelAt;
    public float HP;

    Scene currentScene;

    public void SavePlayer()
    {
        currentScene = GetComponent<Inventory>().currentScene;
        lvlIndex = currentScene.buildIndex;
        Currentlvl = lvlIndex;
        HP = currentHP;
        LevelAt = lvl;

        //SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        lvlIndex = data.levelIndex;
        currentHP = data.health;
        lvl = data.levelAt;

        /*Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;
        SceneManager.LoadScene(currentLevel);*/
    }

}
