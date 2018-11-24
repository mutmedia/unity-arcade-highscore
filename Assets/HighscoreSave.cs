using System;
using System.Collections.Generic;

namespace Highscore
{
  [Serializable]
  internal class HighscoreSave
  {
    public List<HighscoreData> Scores = new List<HighscoreData>();
  }
}