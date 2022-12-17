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
    public static float currentHP;

    Scene currentScene;
    public string currentLevel;
    public float HP;

    private float timer = 0f;
    public float period = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        enCount = 0;
        chest = 0;
    }

    // Update is called once per frame
    /*void Update()
    {
        timer += Time.deltaTime;
        if (timer >= period)
        {
            timer = timer - period;
            SaveStats();
            SavePlayer();
        }
    }*/

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        currentLevel = data.level;
        currentHP = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;
        SceneManager.LoadScene(currentLevel);
    }

    public void SaveStats()
    {
        currentScene = SceneManager.GetActiveScene();
        currentLevel = currentScene.name;
        HP = currentHP;
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
