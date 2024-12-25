using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    public Transform doorModel1; // �h�A�̃��f���I�u�W�F�N�g
    public Transform doorModel2; // �h�A�̃��f���I�u�W�F�N�g

    public float openAngle = 90f; // �h�A���J���p�x
    public float openSpeed = 2f;  // �h�A���J�����x
    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        closedRotation = doorModel1.rotation;
        openRotation = Quaternion.Euler(0, openAngle, 0) * closedRotation;


    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // �}�E�X�̍��N���b�N�����o
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == doorModel1) // �h�A���N���b�N���ꂽ�����`�F�b�N
                {
                    isOpen = !isOpen;
                }
                if (hit.transform == doorModel2) // �h�A���N���b�N���ꂽ�����`�F�b�N
                {
                    isOpen = !isOpen;
                }
            }
        }

        if (doorModel1 != null)
        {
            if (isOpen)
            {
                doorModel1.rotation = Quaternion.Slerp(doorModel1.rotation, openRotation, Time.deltaTime * openSpeed);

                doorModel2.rotation = Quaternion.Slerp(doorModel2.rotation, openRotation, Time.deltaTime * openSpeed);

            }
            else
            {
                doorModel1.rotation = Quaternion.Slerp(doorModel1.rotation, closedRotation, Time.deltaTime * openSpeed);

                doorModel2.rotation = Quaternion.Slerp(doorModel2.rotation, closedRotation, Time.deltaTime * openSpeed);

            }
        }
    }
}

