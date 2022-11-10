using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    Animator anim;
    //[SerializeField] Transform spawnPoint;
    public HealthBar healthBar;
    public int Respawn;

    public float HP;

    public float playerHealth
    {
        set
        {
            currentHealth = value;

            if (currentHealth <= 0)
            {
                anim.SetTrigger("deathTrigger");
                //PlayerDefeat();
                Debug.Log("Defeated");
            }
        }
        get
        {
            healthBar.SetHealth(currentHealth);
            Inventory.currentHP = currentHealth;
            return currentHealth;
        }
    }

    public float maxHealth = 4f;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        anim = GetComponent<Animator>();
        Respawn = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlayerDefeat()
    {
        //PlayerMove player = GetComponent<PlayerMove>();
        //player.transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
        SceneManager.LoadScene(Respawn);
    }
}
