using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateShuriken : MonoBehaviour
{
    public float turnSpeed = 5.0f;
    public bool isCol;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //생성된 불릿(클론)의 iscoll이 false면 돌고(날아가는도중) 아님 안돌게
        Bullet bullet = GameObject.Find("Bullet(Clone)").GetComponent<Bullet>();
        isCol = bullet.isCollsion;
        if (isCol == true)
        {
            Debug.Log("부딛침");
            transform.Rotate(Vector3.up,0.0f);
        }
        
        else if (isCol == false)
        {
            transform.Rotate(Vector3.up, turnSpeed);
        }
        
    }
}
