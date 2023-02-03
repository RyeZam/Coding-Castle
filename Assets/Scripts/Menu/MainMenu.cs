using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public bool firstTime;
    public Button lvlBtn;
    public GameObject contBtn;
    public GameObject playBtn;
    int current;
    //public Inventory load;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Title Theme");
        FindObjectOfType<Logo>().Animate();
        LoadPlayer();
        Activatebtn();
        //FindObjectOfType<Inventory>().LoadPlayer();
    }


    public void Activatebtn()
    {
        //Inventory level = GetComponent<Inventory>();
        //FindObjectOfType<Store>().LoadPlayer();
        if (Inventory.crrlvl >= 1) firstTime = false;
        else if (Inventory.crrlvl < 1) firstTime = true;

        if (firstTime == true)
        {
            lvlBtn.interactable = false;
        }
        else
        {
            lvlBtn.interactable = true;
            contBtn.SetActive(true);
            playBtn.SetActive(false);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void ContinueGame()
    {
        current = Inventory.crrlvl;
        SceneManager.LoadScene(current);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        Debug.Log("data is loaded");
        Inventory.crrlvl = data.levelIndex;
        Debug.Log("level index is loaded");
        //crrlvl = currentLevel;
        Debug.Log("level index is passed to crrlvl");
        Debug.Log(Inventory.crrlvl);
        Inventory.currentHP = data.health;
        Debug.Log("health is loaded");
        Inventory.lvl = data.levelAt;
        Debug.Log("level is loaded");
        /*
        currentLevel = Store.lvlIndex;
        lvl = Store.lvl;
        */
        /*Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;*/
        //SceneManager.LoadScene(currentLevel);
    }

    public void LoadSelect()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


    
}
