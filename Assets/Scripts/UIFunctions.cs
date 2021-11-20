using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SparkGameCore;

public class UIFunctions : MonoBehaviour
{
    [SerializeField] GameManeger gameManeger;
    UIManeger ui;

    public void CloseExitPopup()
    {
        gameManeger.CloseExitPopup();
    }



    private void Start()
    {
        ui = UIManeger.GetInstance();
    }

}
