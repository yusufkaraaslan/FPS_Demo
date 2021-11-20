using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountBoard : MonoBehaviour
{
    [SerializeField] TextMesh text;
    [SerializeField] GameObject player;
    int totCount;

    public void RestartBoard()
    {
        totCount = 0;
        text.text = "" + totCount;
    }

    public void UpdateBoard(int count)
    {
        totCount += count;
        text.text = "" + totCount;
    }

    private void Update()
    {
        if (GameManeger.State == GameState.Ingame)
        {
            transform.LookAt(player.transform, Vector3.up);
        }
    }

}
