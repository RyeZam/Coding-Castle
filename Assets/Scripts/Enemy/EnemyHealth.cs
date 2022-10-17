using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    private Animator animate;
    //public int enCount = 0;
    //public GameObject player;
    public float PointstoGive;

    public float Health
    {
        set
        {
            health = value;

            if (health <= 0)
            {
                Defeated();
            }
        }
        get
        {
            return health;
        }
    }

    public float health = 1f;

    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*void OnHit(float damage)
    {
        Debug.Log("Enemy hit for" + damage);
    }*/

    public void Defeated()
    {
        animate.SetTrigger("Defeated");
        Inventory.enCount += PointstoGive;
        //enCount++;
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }

}
