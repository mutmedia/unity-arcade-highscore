using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Highscore
{
  internal class SetName : MonoBehaviour
  {
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Enter;
    public KeyCode Back;
    public int NAME_SIZE = 3;

    Text nameText;
    string name;
    int currentPosition;

    void Start()
    {
      nameText = GetComponent<Text>();

      name = "";
      for (int i = 0; i < NAME_SIZE; i++)
      {
        name += 'A';
      }
    }

    public float blinkTime;
    float timeSinceLastBlink;
    bool isBlink;

    // Update is called once per frame
    void Update()
    {


      if (Input.GetKeyDown(Back))
      {
        currentPosition--;
      }

      {
        var charArray = name.ToCharArray();
        if (Input.GetKeyDown(Down))
        {
          charArray[currentPosition]--;
          if (charArray[currentPosition] < 'A')
          {
            charArray[currentPosition] = 'Z';
          }
          timeSinceLastBlink = 0;
          isBlink = true;
        }

        if (Input.GetKeyDown(Up))
        {
          charArray[currentPosition]++;
          if (charArray[currentPosition] > 'Z')
          {
            charArray[currentPosition] = 'A';
          }
          timeSinceLastBlink = 0;
          isBlink = true;
        }

        if (timeSinceLastBlink > blinkTime)
        {
          isBlink = !isBlink;
          timeSinceLastBlink = 0;
        }

        name = new string(charArray);

        if (isBlink)
        {
          nameText.text = name.Substring(0, currentPosition + 1);
        }
        else
        {
          nameText.text = name.Substring(0, currentPosition);
        }

        timeSinceLastBlink += Time.deltaTime;
        if (Input.GetKeyDown(Enter))
        {
          if (currentPosition + 1 >= NAME_SIZE)
          {
            HighscoreManager.SubmitAndDisplayLeaderboard(name);
            Destroy(this);
          }
          currentPosition++;
        }
      }
    }
  }
}