using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    public float f_JumpPower;
    public bool b_IsStart = false;
    public bool b_IsDead = false;
    public Text Score;
    public float f_Animation = 1.5f;

    private Rigidbody2D m_Rigidbody;
    private Animator m_Animator;
    private int m_iScore;
    private float m_fTime;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !b_IsDead)
        {
            m_Animator.SetBool("Fly", true);
            m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x, f_JumpPower);
            transform.rotation = Quaternion.Euler(0, 0, 15);
        }

        m_fTime += Time.deltaTime;
        if(m_fTime > f_Animation)
            m_Animator.SetBool("Fly", false);

        // Up Euler
        if (m_Rigidbody.velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(transform.rotation.z, 30f, m_Rigidbody.velocity.y / 8f));
        }
        // Down Euler
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(transform.rotation.z, -90f, -m_Rigidbody.velocity.y / 8f));
        }

        if (transform.position.y > 5.2f)
            m_Rigidbody.position = new Vector2(-1.2f, 5.2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Pillar(Clone)")
        {
            ++m_iScore;
            Score.text = m_iScore.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "bg_pillar" || collision.gameObject.name == "bg_tile")
            GameOver();
    }

    void GameOver()
    {
        SceneManager.LoadScene("ScoreScene");
    }
}
