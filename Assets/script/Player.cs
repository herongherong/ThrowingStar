using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Plai ��Ʃ�� https://www.youtube.com/watch?v=LqnPeqoJRFY ����
public class Player : MonoBehaviour
{
    //ĳ���ͳ��� ������ �ؿ� �ִ� isGround���� ���
    float playerHeight = 2f;

    [Header("Movement")] //�̵����� ���

    public float moveSpeed = 6f;
    public float movementMultiplier = 10f;//�̵��ӵ� �߰�

    float rbDrag = 6f;

    //�������� �ΰ� �ʿ�
    float horizontalMovement;
    float verticalMovement;

    bool isGrounded;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //������ٵ� ������Ʈ ��������
        rb.freezeRotation = true;
    }

    private void Update()
    {
        //������ �浹�� Ȯ��, ĳ���� ���� 2f���� �� ������ ���� ����������. 
        //���� �������� ������ Ȯ���ϰ� �Ϸ��� 0.1f�� ����
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight / 2 + 0.1f);
        MyInput();
        ControlDrag(); 
    }

    void MyInput() //�Է�ó�����̶� ��.
    {
        //����, �����̵��� ���� �� ����
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");


        //�츮�� ����ϴ� �����̵�, �÷��̾ �ٶ󺸴� �������� �̵�.
        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
    }

    void ControlDrag()
    {
        rb.drag = rbDrag;
    }



    //������ �Ų����� �ϱ� ���� �߰��� ��.
    private void FixedUpdate()
    {
        MovePlayer();
    }

    //�̵�
    void MovePlayer()
    {//�̵��������� ���� ����, ��ֶ������ ���� ������ �밢�� ��Ʈ2������.
        rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
    }

}
