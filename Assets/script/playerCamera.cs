using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour
{
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    Camera cam;

    float mouseX;
    float mouseY;

    float multiplier = 0.01f;

    float xRotation;
    float yRotation;

    private void Start()
    {//카메라를 자식으로 가져와서 전달하는 거라 함.
        cam = GetComponentInChildren<Camera>();

        //게임밖으로 커서 못나가게 락걸기
        Cursor.lockState = CursorLockMode.Locked;
        //커서 숨기기
        Cursor.visible = false;

    }

    private void Update()
    {
        MyInput();

        //벡터3랑 달라서 바꿔줘야하는걸로 알고있음. (오일러로)
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void MyInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX * sensX* multiplier;
        xRotation -= mouseY * sensY * multiplier;

        //위아래 허리꺾여서 못보게 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


    }


}
