using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SparkGameCore;

public class LevelManeger : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Level level; // TODO : Add multible levels

    public void Init()
    {
        level.ClearLevel();
        player.Init();
    }

    public void StartLevel()
    {
        level.LoadLevel();
        player.StartPlayer(level.GetPlayerStartPose());
    }

    public void EndLevel()
    {
        player.ClosePlayer();
        level.ClearLevel();
    }
}
