using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text t_Score;
    public Text t_Best;

    private static int i_Score;
    private static int i_Best;

    void Start()
    {
        if (i_Score != 0)
            PlayerPrefs.SetInt("Score", i_Score);

        if (i_Best != 0)
            PlayerPrefs.SetInt("Score", i_Best);
    }

    private void Update()
    {
        ScoreLoad();
    }

    void ScoreLoad()
    {
        if (PlayerPrefs.HasKey("Score"))
            t_Score.text = PlayerPrefs.GetInt("Score").ToString();
        else
            t_Score.text = 0.ToString();

        if (PlayerPrefs.HasKey("Best"))
            t_Best.text = PlayerPrefs.GetInt("Best").ToString();
        else
            t_Best.text = 0.ToString();
    }

    void ScoreCheck(int count)
    {
        if (PlayerPrefs.HasKey("Best"))
        {
            int temp = 0;
            temp = PlayerPrefs.GetInt("Best");

            if (temp <= count)
            {
                i_Best = count;
                PlayerPrefs.DeleteKey("Best");
                PlayerPrefs.SetInt("Best", count);
            }
        }

        i_Best = count;
        PlayerPrefs.SetInt("Best", count);
    }

    public void Count(int count)
    {
        i_Score = count;
        ScoreCheck(count);
        PlayerPrefs.SetInt("Score", count);
    }
}
