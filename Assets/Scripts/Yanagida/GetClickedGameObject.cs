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

            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;

                // クリックしたオブジェクトのイベント確認
                activeobjcontroller = clickedGameObject.GetComponent<ActiveObjController>();
                activeobjcontroller.GetActive();
            }

            Debug.Log(clickedGameObject);
        }
    }
}