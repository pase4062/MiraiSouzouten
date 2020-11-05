using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{

    private bool disturbflug;       // お邪魔フラグ
    private bool move;       // お邪魔フラグ
    Vector3 redirection = new Vector3(7f, 0.9f, 0f);      // デフォルト位置
    Vector3 direction = new Vector3(7f, -2.5f, 0f);      // デフォルト位置

    float speed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        disturbflug = false;
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(disturbflug)
        {
            if(move)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, direction, step);

                if (transform.position == direction)
                {
                    move = false;
                }
            }
            else
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, redirection, step);

                if (transform.position == redirection)
                {
                    move = true;
                    disturbflug = false;
                }
            }
            
        }
    }

    public void Disturb()
    {
        disturbflug = true;
        Debug.Log("aa");
    }
}
