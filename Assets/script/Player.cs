using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Plai 유튜브 https://www.youtube.com/watch?v=LqnPeqoJRFY 참조
public class Player : MonoBehaviour
{
    //캐릭터높이 정해줌 밑에 있는 isGround에서 사용
    float playerHeight = 2f;

    [Header("Movement")] //이동변수 헤더

    public float moveSpeed = 6f;
    public float movementMultiplier = 10f;//이동속도 추가

    float rbDrag = 6f;

    //수직방향 두개 필요
    float horizontalMovement;
    float verticalMovement;

    bool isGrounded;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //리지드바디 컴포넌트 가져오기
        rb.freezeRotation = true;
    }

    private void Update()
    {
        //땅과의 충돌을 확인, 캐릭터 높이 2f에서 반 나누고 땅과 높이측정함. 
        //닿지 않을떄도 있으니 확실하게 하려고 0.1f로 보완
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight / 2 + 0.1f);
        MyInput();
        ControlDrag(); 
    }

    void MyInput() //입력처리용이라 함.
    {
        //수직, 수평이동을 얻은 후 적용
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");


        //우리가 사용하는 수평이동, 플레이어가 바라보는 방향으로 이동.
        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
    }

    void ControlDrag()
    {
        rb.drag = rbDrag;
    }



    //움직임 매끄럽게 하기 위한 추가라 함.
    private void FixedUpdate()
    {
        MovePlayer();
    }

    //이동
    void MovePlayer()
    {//이동방향으로 힘을 가함, 노멀라이즈드 곱한 이유는 대각선 루트2때문에.
        rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
    }

}
