using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Highscore
{
  public class ScoreManager : MonoBehaviour
  {
    public int Score;
    public static ScoreManager Instance;

    public static int GetScore()
    {
      return Instance.Score;
    }

    public static void SetScore(int value)
    {
      Instance.Score = value;
    }

    void Awake()
    {
      if (Instance == null)
      {
        Instance = this;
      }

      if (Instance != this)
      {
        Destroy(this.gameObject);
      }

      DontDestroyOnLoad(this.gameObject);
    }
  }
}