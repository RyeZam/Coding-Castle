using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] levelsbtn;

    // Start is called before the first frame update
    void Start()
    {
        Activate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        //Inventory level = GetComponent<Inventory>();
        int lvl = Store.lvl;

        levelsbtn = new Button[16];
        for (var i = 1; i <= 15; i++)
        {
            Button _lvlbtn = GameObject.Find("lvl" + i).GetComponent<Button>();
            levelsbtn[i] = _lvlbtn;
            levelsbtn[i].interactable = false;
        }

        for (int i = 1; i <= lvl; i++)
        {
            levelsbtn[i].interactable = true;
        }
    }
}
