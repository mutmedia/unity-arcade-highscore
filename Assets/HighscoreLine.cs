using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Highscore
{
  internal class HighscoreLine : MonoBehaviour
  {
    [SerializeField]
    Text NomeText;
    [SerializeField]
    Text ScoreText;

    public void Set(string name, int score)
    {
      NomeText.text = name;
      ScoreText.text = "" + score;
    }
  }
}