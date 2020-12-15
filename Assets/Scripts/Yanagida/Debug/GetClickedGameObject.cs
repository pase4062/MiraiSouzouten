using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetClickedGameObject : MonoBehaviour
{

    GameObject clickedGameObject;
    ActiveObjController activeobjcontroller;

    void Update()
    {
    
        if (Input.GetMouseButtonDown(0))
        {
    
            clickedGameObject = null;
            activeobjcontroller = null;

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            RaycastHit2D hit2d = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;
    
                // クリックしたオブジェクトのイベント確認
                activeobjcontroller = clickedGameObject.GetComponent<ActiveObjController>();
                activeobjcontroller.GetActive();
            }
            Debug.Log(hit2d);
            Debug.Log(clickedGameObject);
            Debug.DrawLine(mousePos,
        mousePos + new Vector3(0.1f,0.0f,0.0f), Color.blue);

        }
    }

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        GameObject obj = getClickObject();
    //        if (obj != null)
    //        {
    //            // 以下オブジェクトがクリックされた時の処理
    //            // クリックしたオブジェクトのイベント確認
    //            activeobjcontroller = obj.GetComponent<ActiveObjController>();
    //            activeobjcontroller.GetActive();
    //        }
    //        Debug.Log(clickedGameObject);
    //    }
    //
    //}
    //// 左クリックしたオブジェクトを取得する関数(2D)
    //private GameObject getClickObject()
    //{
    //    GameObject result = null;
    //    // 左クリックされた場所のオブジェクトを取得
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
    //        if (collition2d)
    //        {
    //            result = collition2d.transform.gameObject;
    //        }
    //    }
    //    return result;
    //}
}