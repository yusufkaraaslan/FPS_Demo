using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SparkGameCore;

public class GameManeger : MonoBehaviour
{
    public static GameState State { get => state; }
    static GameState state;

    [SerializeField] LevelManeger levelManeger;
    UIManeger ui;

    public void Init()
    {
        ui = UIManeger.GetInstance();
        ui.OpenUIClean("Menu");
        levelManeger.Init();
        state = GameState.Menu;
    }

    public void StartGame()
    {
        levelManeger.StartLevel();
        ui.OpenUIClean("Ingame");

        state = GameState.Ingame;
    }

    public void ReturnMenu()
    {
        levelManeger.EndLevel();
        ui.OpenUIClean("Menu");

        state = GameState.Menu;
    }

    public void ResumeGame()
    {
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