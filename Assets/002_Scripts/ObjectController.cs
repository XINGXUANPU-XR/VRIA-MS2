using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public GameObject switchObject; // クリックされるスイッチオブジェクト
    public Light[] roomLights;         // 部屋のライトオブジェクト

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // マウスの左クリックを検出
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == switchObject) // スイッチオブジェクトがクリックされたかをチェック
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
                light.enabled = !light.enabled; // ライトのオンオフを切り替える
            }
        }
    }

}
