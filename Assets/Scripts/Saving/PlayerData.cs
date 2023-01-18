using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int levelIndex;
    public float health;
    public float[] position;
    public int levelAt;

    public PlayerData (Store player)
    {
        levelIndex = player.Currentlvl;
        health = player.HP;
        levelAt = player.LevelAt;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
