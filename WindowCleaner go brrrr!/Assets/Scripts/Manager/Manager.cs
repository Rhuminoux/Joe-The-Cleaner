using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public enum State
    {
        MAINMENU,
        GAMEMENU,
        GAME
    }

    public GameObject inGameMenu;
    public GameObject deathMenu;
    public GameObject mainMenu;

    public State _currentState;


    //Reset Data
    public GameObject envPrefab;
    
    public GameObject joystick;

    private GameObject _currentEnv;


    // Start is called before the first frame update
    void Start()
    {
        _currentState = State.MAINMENU;
        ResetGame();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void SetStateGame()
    {
        _currentState = State.GAME;
        Time.timeScale = 1;
    }

    public void SetStateMainMenu()
    {
        _currentState = State.MAINMENU;
        Time.timeScale = 0;
    }

    public void SetStateGameMenu()
    {
        _currentState = State.GAMEMENU;
        Time.timeScale = 0;
    }

    public void LeaveOptionMenu()
    {
        if (_currentState == State.MAINMENU)
        {
            mainMenu.SetActive(true);
        }
        else
            inGameMenu.SetActive(true);
    }

    public void SetEnvActive(bool boolean)
    {
        _currentEnv.SetActive(boolean);
    }

    public void ResetGame()
    {
        if (_currentEnv)
            Destroy(_currentEnv);
        _currentEnv = GameObject.Instantiate(envPrefab);
    }
}
