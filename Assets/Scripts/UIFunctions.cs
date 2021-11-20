using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using SparkGameCore;

public class UIFunctions : MonoBehaviour
{
    [SerializeField] GameManeger gameManeger;
    
    [SerializeField] Gun gun;
    [SerializeField] Toggle delayedToggle, BiggerToggle, RedToddel;

    UIManeger ui;

    public void CloseExitPopup()
    {
        gameManeger.CloseExitPopup();
    }

    public void UpdateBulletMod()
    {
        gun.UpdateBulletMod(delayedToggle.isOn, BiggerToggle.isOn, RedToddel.isOn);
    }

    private void Start()
    {
        ui = UIManeger.GetInstance();
    }

}
