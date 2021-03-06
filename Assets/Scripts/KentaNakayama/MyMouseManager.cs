﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMouseManager : MonoBehaviour
{
    GameObject clickedGameObject;
    MyObjController objcontroller;

    public GameObject[] playerIcons;

    public GameObject OnObject;
    public GameObject OffObject;

    public int destroyCount = 0;

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            clickedGameObject = null;
            objcontroller = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;

                // ダメージタグチェック
                if (clickedGameObject.gameObject.CompareTag("damage"))
                {
                    destroyCount += 1;
                    UpdatePlayerIcons();
                }

                // 切り替えオブジェクトチェック
                if(clickedGameObject.gameObject.CompareTag("SwitchOff"))
                {
                    OffObject.SetActive(false);
                    OnObject.SetActive(true);
                }
                else if (clickedGameObject.gameObject.CompareTag("SwitchOn"))
                {
                    OffObject.SetActive(true);
                    OnObject.SetActive(false);
                }

                // クリックしたオブジェクトのイベント確認
                //objcontroller = clickedGameObject.GetComponent<MyObjController>();
                //objcontroller.GetActive();
            }

            Debug.Log(clickedGameObject);
        }
    }

    void UpdatePlayerIcons()
    {
        
        for (int i = 0; i < playerIcons.Length; i++)
        {
            if (destroyCount <= i)
            {
                playerIcons[i].SetActive(true);
            }
            else
            {
                playerIcons[i].SetActive(false);
            }
        }
    }


}
