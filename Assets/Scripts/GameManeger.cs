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
        Cursor.lockState = CursorLockMode.Confined;
        levelManeger.StartLevel();
        ui.OpenUIClean("Ingame");

        state = GameState.Ingame;
    }

    public void ReturnMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
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
        Cursor.lockState = CursorLockMode.Confined;
        state = GameState.InGameMenu;
    }

    public void CloseExitPopup()
    {
        ui.CloseUI("ExitPopup");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        state = GameState.Ingame;
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            switch (state)
            {
                case GameState.Ingame:
                    ui.OpenUI("ExitPopup");
                    state = GameState.InGameMenu;
                    break;
                case GameState.InGameMenu:
                    ui.CloseUI("ExitPopup");
                    state = GameState.Ingame;
                    break;
            }
        }
    }

}

public enum GameState
{
    Menu, Ingame, InGameMenu
}