using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string level;
    public float health;
    public float[] position;

    public PlayerData (Inventory player)
    {
        level = player.currentLevel;
        health = player.HP;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
