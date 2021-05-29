using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    GameObject TargetObj;
    Vector3 offset;
    Transform tr;

    bool isCollsion;

    public float bulletSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        TargetObj = null;
        isCollsion = false;
        offset = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (isCollsion)
        {
            transform.position = TargetObj.transform.position - offset;
        }
        else
        {
            transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            TargetObj = GameObject.FindWithTag("Enemy");
            offset = TargetObj.transform.position - transform.position;
            isCollsion = true;
            Destroy(gameObject, 3);
            Destroy(TargetObj, 3);
        }

        if (other.tag == "Wall")
        {
            TargetObj = GameObject.FindWithTag("Enemy");
            offset = TargetObj.transform.position - transform.position;
            isCollsion = true;
            ExpBarrel();
            Destroy(gameObject, 3);
        }

    }

    void ExpBarrel()
    {
        //������ ������ �߽����� 10.0f �ݰ� ���� ���� �ִ� Collider ��ü ����
        Collider[] colls = Physics.OverlapSphere(tr.position, 1000.0f, 1 << 4);

        //������ Collider ��ü�� ���߷� ����
        foreach (Collider coll in colls)
        {
            Rigidbody rbody = coll.GetComponent<Rigidbody>();

            rbody.mass = 1.0f;
            rbody.AddExplosionForce(1000.0f, tr.position, 10.0f, 1300.0f);

        }

    }
}