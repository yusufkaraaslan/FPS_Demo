using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SparkGameCore;

public class GameManeger : MonoBehaviour
{
    public static GameState State { get => state; }
    static GameState state;

    UIManeger ui;
    CameraSystem cam;

    [SerializeField] LevelManeger levelManeger;

    [SerializeField] ImmediateCamLayout menuCamPos;

    public void Init()
    {
        ui = UIManeger.GetInstance();
        cam = CameraSystem.GetInstance();

        Cursor.lockState = CursorLockMode.Confined;
        ui.OpenUIClean("Menu");
        levelManeger.Init();
        state = GameState.Menu;
    }

    public void StartGame()
    {
        Cursor.visible = false;
        levelManeger.StartLevel();
        ui.OpenUIClean("Ingame");

        state = GameState.Ingame;
    }

    public void ReturnMenu()
    {
        Cursor.visible = true;
        cam.SetCam("Main", new ImmediateCam(), menuCamPos);
        levelManeger.EndLevel();
        ui.OpenUIClean("Menu");

        state = GameState.Menu;
    }

    public void ResumeGame()
    {
        state = GameState.Ingame;
    }

    public void OpenExitPopup()
    {
        ui.OpenUI("ExitPopup");
        Cursor.visible = true;
        state = GameState.InGameMenu;
    }

    public void CloseExitPopup()
    {
        ui.CloseUI("ExitPopup");
        Cursor.visible = false;
        state = GameState.Ingame;
    }

    private void Start()
    {
        Init();
    }

    void TriggerPopup(string panelName)
    {
        switch (state)
        {
            case GameState.Ingame:
                Cursor.visible = true;
                ui.OpenUI(panelName);
                state = GameState.InGameMenu;
                break;
            case GameState.InGameMenu:
                Cursor.visible = false;
                ui.CloseUI(panelName);
                state = GameState.Ingame;
                break;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            TriggerPopup("ExitPopup");
        }
        else if (Input.GetKeyDown("q"))
        {
            TriggerPopup("BulletMod");
        }
    }

}

public enum GameState
{
    Menu, Ingame, InGameMenu
}