using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public GameObject switchObject; // �N���b�N�����X�C�b�`�I�u�W�F�N�g
    public Light[] roomLights;         // �����̃��C�g�I�u�W�F�N�g

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // �}�E�X�̍��N���b�N�����o
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == switchObject) // �X�C�b�`�I�u�W�F�N�g���N���b�N���ꂽ�����`�F�b�N
                {
                    ToggleLight();
                }
            }
        }
    }

    void ToggleLight()
    {
        foreach (Light light in roomLights)
        {
            if (light != null)
            {
                light.enabled = !light.enabled; // ���C�g�̃I���I�t��؂�ւ���
            }
        }
    }

}
