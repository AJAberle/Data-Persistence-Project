using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public InputField playerName;
    public Text HighscoreText; 

    private void Start()
    {
        playerName.text = SaveHandler.Instance.playerName;
        HighscoreText.text = $"Best Score : {SaveHandler.Instance.highscoreHolder} : {SaveHandler.Instance.highscore}";
    }
    public void StartGame()
    {
        SaveHandler.Instance.playerName = playerName.text;
        SaveHandler.Instance.SaveGame(); 
        SceneManager.LoadScene(1); 
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }
}
