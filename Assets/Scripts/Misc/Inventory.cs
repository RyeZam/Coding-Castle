using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public TextMeshProUGUI counter;

    public static int count = 0;
    public static float enCount = 0;
    public static int chest = 0;
    public static float currentHP;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        enCount = 0;
        chest = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
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
