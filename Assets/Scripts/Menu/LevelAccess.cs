using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelAccess : MonoBehaviour
{
    public int order;

    public void LoadScene()
    {
        Assign(order);
    }

    public void Assign(int index)
    {
        switch (index)
        {
            case 1:
                SceneManager.LoadScene("1A");
                break;
            case 2:
                SceneManager.LoadScene("2A");
                break;
            case 3:
                SceneManager.LoadScene("3A");
                break;
            case 4:
                SceneManager.LoadScene("4A");
                break;
            case 5:
                SceneManager.LoadScene("5A");
                break;
            case 6:
                SceneManager.LoadScene("6A");
                break;
            case 7:
                SceneManager.LoadScene("7A");
                break;
            case 8:
                SceneManager.LoadScene("8A");
                break;
            case 9:
                SceneManager.LoadScene("9A");
                break;
            case 10:
                SceneManager.LoadScene("10A");
                break;
            case 11:
                SceneManager.LoadScene("11A");
                break;
            case 12:
                SceneManager.LoadScene("12A");
                break;
            case 13:
                SceneManager.LoadScene("13A");
                break;
            case 14:
                SceneManager.LoadScene("14A");
                break;
            case 15:
                SceneManager.LoadScene("15A");
                break;
        }
    }

}
