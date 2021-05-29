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
    {//ī�޶� �ڽ����� �����ͼ� �����ϴ� �Ŷ� ��.
        cam = GetComponentInChildren<Camera>();

        //���ӹ����� Ŀ�� �������� ���ɱ�
        Cursor.lockState = CursorLockMode.Locked;
        //Ŀ�� �����
        Cursor.visible = false;

    }

    private void Update()
    {
        MyInput();

        //����3�� �޶� �ٲ�����ϴ°ɷ� �˰�����. (���Ϸ���)
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void MyInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX * sensX* multiplier;
        xRotation -= mouseY * sensY * multiplier;

        //���Ʒ� �㸮������ ������ 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


    }


}
