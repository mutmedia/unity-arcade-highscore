using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Highscore
{
  internal class HighscoreDisplay : MonoBehaviour
  {
    public HighscoreLine lineTemplate;
    public Transform container;
    public int NumberOfScores;
    void Start()
    {

    }

    public void Create(List<HighscoreData> scores)
    {
      scores.OrderByDescending(s => s.Score).Take(NumberOfScores).ToList().ForEach(s =>
      {
        var line = Instantiate(lineTemplate, container);
        line.Set(s.Name, s.Score);
      });
      lineTemplate.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
  }
}
