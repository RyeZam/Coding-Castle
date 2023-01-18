using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public bool firstTime;
    public Button lvlBtn;
    int current = 0;
    //public Inventory load;

    private void Start()
    {
        //load.LoadPlayer();
        Activatebtn();
        FindObjectOfType<Logo>().Animate();
    }


    public void Activatebtn()
    {
        //Inventory level = GetComponent<Inventory>();
        if (Store.lvl >= 1) firstTime = false;
        else firstTime = true;

        if (firstTime == true)
        {
            lvlBtn.interactable = false;
        }
        else
        {
            lvlBtn.interactable = true;
        }
    }

    public void PlayGame()
    {
        if (firstTime == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
        else if (firstTime == false)
        {
            current = Store.lvlIndex;
            SceneManager.LoadScene(current);
        }
       
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
