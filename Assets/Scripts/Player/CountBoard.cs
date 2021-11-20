using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountBoard : MonoBehaviour
{
     [SerializeField] TextMesh text;
    int totCount;

    public void RestartBoard()
    {
        totCount = 0;
    }

    public void UpdateBoard(int count)
    {
        totCount += count;
        text.text = "" + totCount;
    }

}
