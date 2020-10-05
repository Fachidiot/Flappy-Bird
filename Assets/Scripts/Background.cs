using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject g_Sky;
    public float f_SkyScrollSpeed;
    public float f_SkySize;
    public float f_SkyClip;
    private int Skycount;

    public GameObject g_Tile;
    public float f_TileScrollSpeed;
    public float f_TileSize;
    public float f_TileClip;
    private int Tilecount;

    private float m_fSkyNextTime = 0;
    private float m_fTileNextTime = 0;
    private GameObject[] m_BgSkys = new GameObject[3];
    private GameObject[] m_BgTiles = new GameObject[3];
    private int m_iSkyIndex = 0;
    private int m_iTileIndex = 0;

    private void Start()
    {
        Skycount++;
        m_BgSkys[m_iSkyIndex] = (GameObject)Instantiate(g_Sky, new Vector3(0, 0, f_SkyClip), Quaternion.identity);
        m_iSkyIndex++;
        Tilecount++;
        m_BgTiles[m_iTileIndex] = (GameObject)Instantiate(g_Tile, new Vector3(0, 0, f_TileClip), Quaternion.identity);
        m_iTileIndex++;
    }

    void Update()
    {
        Sky();
        Tile();
    }

    void Sky()
    {
        if (Time.time > m_fSkyNextTime && Skycount < 3)
        {
            m_fSkyNextTime = Time.time + f_SkySize;
            m_BgSkys[m_iSkyIndex] = (GameObject)Instantiate(g_Sky, new Vector3(f_SkySize, 0, f_SkyClip), Quaternion.identity);
            Skycount++;

            m_iSkyIndex++;
            if (m_iSkyIndex >=3)
                m_iSkyIndex = 0;
        }

        for (int i = 0; i < 3; i++)
        {
            if (m_BgSkys[i])
            {
                m_BgSkys[i].transform.Translate(0.01f * f_SkyScrollSpeed, 0, 0);

                if (m_BgSkys[i].transform.position.x < -f_SkySize)
                {
                    Destroy(m_BgSkys[i]);
                    Skycount--;
                }
            }
        }
    }

    void Tile()
    {
        if (Time.time > m_fTileNextTime && Tilecount < 3)
        {
            m_fTileNextTime = Time.time + f_TileSize * 1.5f;
            m_BgTiles[m_iTileIndex] = (GameObject)Instantiate(g_Tile, new Vector3(f_TileSize, 0, f_TileClip), Quaternion.identity);
            Tilecount++;

            m_iTileIndex++;
            if (m_iTileIndex >= 3)
                m_iTileIndex = 0;
        }

        for (int i = 0; i < 3; i++)
        {
            if (m_BgTiles[i])
            {
                m_BgTiles[i].transform.Translate(0.01f * f_TileScrollSpeed, 0, 0);

                if (m_BgTiles[i].transform.position.x < -f_TileSize)
                {
                    Destroy(m_BgTiles[i]);
                    Tilecount--;
                }
            }
        }
    }
}
