using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float f_FlySpeed;
    public float f_Gravity;
    
    private Vector3 m_Movement;
    private float m_fX;
    private float m_fY;

    void Start()
    {
        
    }
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            gameObject.GetComponent<Rigidbody>().AddForce(0, 300, 0);
        }
    }
}
