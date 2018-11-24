using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Highscore
{
  internal class HighscoreManager : MonoBehaviour
  {
    // Use this for initialization
    HighscoreSave save;
    int playerScore;
    static HighscoreManager instance;

    [SerializeField]
    GameObject SetName;

    [SerializeField]
    HighscoreDisplay Leaderboard;

    void Start()
    {
      if (instance == null)
      {
        instance = this;
      }

      instance.save = Load();
      print("LOADING");
      foreach (var s in save.Scores)
      {
        print(s.Name + ": " + s.Score);
      }
      print("LOADED");
      instance.playerScore = ScoreManager.GetScore();

      SetName.SetActive(true);
      Leaderboard.gameObject.SetActive(false);
    }

    static IEnumerator PressAnyKeyToRestart()
    {
      yield return new WaitForSeconds(1);
      while (true)
      {
        if (Input.anyKeyDown)
        {
          UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        yield return null;
      }
    }

    public static void SubmitAndDisplayLeaderboard(string name)
    {
      HighscoreData duplinha = new HighscoreData();
      duplinha.Name = name;
      duplinha.Score = instance.playerScore;

      instance.save.Scores.Add(duplinha);

      Save(instance.save);
      instance.SetName.SetActive(false);
      instance.Leaderboard.gameObject.SetActive(true);
      instance.Leaderboard.Create(instance.save.Scores);
      instance.StartCoroutine(PressAnyKeyToRestart());
    }

    public static HighscoreSave Load()
    {
      if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
      {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
        HighscoreSave save = (HighscoreSave)bf.Deserialize(file);
        file.Close();
        return save;
      }
      return new HighscoreSave();
    }

    public static void Save(HighscoreSave save)
    {
      BinaryFormatter bf = new BinaryFormatter();
      FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
      print("Saved at " + Application.persistentDataPath + "/gamesave.save");
      bf.Serialize(file, save);
      file.Close();
    }
  }
}
