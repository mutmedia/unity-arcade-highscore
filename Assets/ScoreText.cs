using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Highscore
{
  internal class ScoreText : MonoBehaviour
  {
    Text text;
    // Use this for initialization
    void Start()
    {
      text = GetComponent<Text>();
      text.text = "Score: " + ScoreManager.GetScore();
    }

    // Update is called once per frame
    void Update()
    {
    }
  }
}