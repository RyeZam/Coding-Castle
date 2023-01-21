using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Inventory : MonoBehaviour
{
    public TextMeshProUGUI counter;

    public static int count = 0;
    public static int enCount = 0;
    public static int chest = 0;
    public static int fountain = 0;
    public static float currentHP;
    public static int lvl;
    public static int crrlvl;
    public static int deathCount;

    public int levelAt;

    public Scene currentScene;
    public int currentLevel;
    public float HP;

    private float timer = 0f;
    private float period = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        enCount = 0;
        chest = 0;
        fountain = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= period)
        {
            timer =- period;
            SaveStats();
            //SavePlayer();
        }
    }


    /*public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        currentLevel = data.levelIndex;
        crrlvl = currentLevel;
        currentHP = data.health;
        lvl = data.levelAt;

        currentLevel = Store.lvlIndex;
        lvl = Store.lvl;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;
        SceneManager.LoadScene(currentLevel);
    }*/


    public void SaveStats()
    {
        currentScene = SceneManager.GetActiveScene();
        currentLevel = currentScene.buildIndex;
        //Debug.Log(currentLevel);
        crrlvl = currentLevel;
        HP = currentHP;
        levelAt = lvl;
        FindObjectOfType<Store>().SavePlayer();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectable"))
        {
            Collect(other.GetComponent<Collectable>());
        }
    }

    private void Collect(Collectable collectable)
    {
        if (collectable.Collect())
        {
            Debug.Log("Collected.");
            count++;
        }
        UpdateGUI();
    }

    private void UpdateGUI()
    {
        counter.text = count.ToString();
    }
}
