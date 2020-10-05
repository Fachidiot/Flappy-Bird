using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text t_Score;
    public Text t_Best;

    private SpriteRenderer m_spriteRender;

    void Start()
    {
        m_spriteRender = GetComponent<SpriteRenderer>();
    }

    void ScoreCheck()
    {

    }

    public void Count(int count)
    {
        t_Score.text = count.ToString();
    }
}
