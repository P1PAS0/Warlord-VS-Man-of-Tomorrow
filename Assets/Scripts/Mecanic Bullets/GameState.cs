using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Normal,
    Slowed
}

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    private GameState currentState;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentState = GameState.Normal;
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
        switch (newState)
        {
            case GameState.Normal:
                Time.timeScale = 1f;
                break;
            case GameState.Slowed:
                Time.timeScale = 0.5f;
                break;
        }
    }

    public GameState GetCurrentState()
    {
        return currentState;
    }
}
