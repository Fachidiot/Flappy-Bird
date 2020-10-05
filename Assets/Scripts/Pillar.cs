using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public GameObject g_Pillar;
    public Bird bird;
    public float MakeingTime;

    private float m_fNextTime = 0;
    private GameObject[] m_Pillars = new GameObject[3];
    private int m_iIndex = 0;

    void Update()
    {
        if (bird.b_IsDead)
            return;

        if (Time.time > m_fNextTime)
        {
            m_fNextTime = Time.time + MakeingTime;
            m_Pillars[m_iIndex] = (GameObject)Instantiate(g_Pillar, new Vector3(4, Random.Range(-1.3f, 1.5f), 1), Quaternion.identity);

            m_iIndex++;
            if (m_iIndex >= m_Pillars.Length)
                m_iIndex = 0;
        }

        for (int i = 0; i < m_Pillars.Length; i++)
        {
            if (m_Pillars[i])
            {
                m_Pillars[i].transform.Translate(-0.03f, 0, 0);
                if (m_Pillars[i].transform.position.x < -4)
                    Destroy(m_Pillars[i]);
            }
        }
    }
}
