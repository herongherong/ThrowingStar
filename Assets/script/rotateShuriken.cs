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
        //������ �Ҹ�(Ŭ��)�� iscoll�� false�� ����(���ư��µ���) �ƴ� �ȵ���
        Bullet bullet = GameObject.Find("Bullet(Clone)").GetComponent<Bullet>();
        isCol = bullet.isCollsion;
        if (isCol == true)
        {
            Debug.Log("�ε�ħ");
            transform.Rotate(Vector3.up,0.0f);
        }
        
        else if (isCol == false)
        {
            transform.Rotate(Vector3.up, turnSpeed);
        }
        
    }
}
