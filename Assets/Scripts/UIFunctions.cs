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
        ui.CloseUI("ExitPopup");
        gameManeger.ResumeGame();
    }



    private void Start()
    {
        ui = UIManeger.GetInstance();
    }

}
