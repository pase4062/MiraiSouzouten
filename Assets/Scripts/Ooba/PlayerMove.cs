using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{

    private Animator anim;
    //　移動速度
    float speed = 5.0f;
    Vector3 preMousePos;

    GameObject apple;
    AppleController script;
    // Start is called before the first frame update
    void Start()
    {
        apple = GameObject.Find("apple");
        anim = GetComponent<Animator>();
        script = apple.GetComponent<AppleController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            preMousePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosDiff = Input.mousePosition - preMousePos;
            preMousePos = Input.mousePosition;
            Vector3 newPos = this.gameObject.transform.position + new Vector3(mousePosDiff.x / Screen.width, 0, mousePosDiff.y / Screen.height) * speed;

            this.transform.position = newPos;
            anim.SetTrigger("Wait to Move");
           // script.Downact();

        }
        else
        {
            anim.SetTrigger("Move to Wait");
        }
       
    }

    
}
