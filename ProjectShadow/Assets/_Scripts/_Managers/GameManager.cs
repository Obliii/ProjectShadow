using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public enum GameState
{
    GAMESTATE_None,
    GAMESTATE_Overworld,
    GAMESTATE_Dialogue,
    GAMESTATE_Battle,
};
public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public static GameManager Instance {  get { return _instance; } }

    private void Awake()
    {
        if(Instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Statics
    public static bool IsPaused = false;
    public static bool IsInCombat = false;

    public static GameState GameState;

    // Functions
    public static void TogglePause()
    {

        //Pause menu.
        IsPaused = !IsPaused;

        if (IsPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public static void ChangeGameState(GameState state)
    {
        GameState = state;

        //Possible Event to shoot so that other functions know that
        //The Game State has changed.
        //This could change the music, and help fade the game to dark if we're starting the battle.
    }
}
