using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    [SerializeField] GameObject gameGround;
    [SerializeField] PlayerPlaceholder playerStartPose;

    public void LoadLevel()
    {
        gameGround.SetActive(true);
    }

    public void ClearLevel()
    {
        gameGround.SetActive(false);
    }

    public Transform GetPlayerStartPose()
    {
        return playerStartPose.gameObject.transform;
    }

}
