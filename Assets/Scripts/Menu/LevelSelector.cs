using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneMove selectScn;

    public Button[] levelButtons;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Level");

        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelReached = Inventory.lvl;

            if(i > levelReached-1)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    public void Select(string levelName)
    {
        selectScn.SceneSelect(levelName);
    }

    public void GoBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
