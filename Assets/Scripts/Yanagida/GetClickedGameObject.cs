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
    
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
    
            if (hit2d.collider)
            {
                clickedGameObject = hit2d.transform.gameObject;
    
                // クリックしたオブジェクトのイベント確認
                activeobjcontroller = clickedGameObject.GetComponent<ActiveObjController>();
                activeobjcontroller.GetActive();
            }
            Debug.Log(hit2d);
            Debug.Log(clickedGameObject);
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