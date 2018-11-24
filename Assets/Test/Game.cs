using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Highscore;

namespace HighscoreSample
{
  public class Game : MonoBehaviour
  {

    int LastTimePressed;
    string key = "score";
    System.DateTime initialDateTime = new DateTime(2018, 1, 1);
    int currentScore => (int)(System.DateTime.Now - initialDateTime).TotalSeconds - LastTimePressed;
    public UnityEngine.UI.Text text;
    // Use this for initialization
    void Start()
    {
      if (!PlayerPrefs.HasKey(key))
      {
        int initialTime = (int)(System.DateTime.Now - initialDateTime).TotalSeconds;
        PlayerPrefs.SetInt(key, initialTime);
      }
      LastTimePressed = PlayerPrefs.GetInt(key, 0);
    }

    void Reset()
    {
      ScoreManager.SetScore(currentScore);
      LastTimePressed = (int)(System.DateTime.Now - initialDateTime).TotalSeconds;
      //PlayerPrefs.SetInt(key, LastTimePressed);
      PlayerPrefs.DeleteKey(key);
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        Reset();
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
      }
      text.text = "Score: " + currentScore;
    }
  }
}