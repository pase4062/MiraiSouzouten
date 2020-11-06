using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    // private変数
    private bool Downf;         // 落下フラグ
    private bool Eatf;          // 捕食可能フラグ

    [SerializeField]
    GameObject LeafObj;         // 落下する葉っぱオブジェクト


    private Rigidbody rb;       // 重力変数
    // Start is called before the first frame update
    void Start()
    {
        Downf = false;

        //Rigidbodyを取得
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -3.0f && Downf)
        {
            //重力を停止させる
            rb.useGravity = false;
            rb.velocity = Vector3.zero;

            Downf = false;
            Debug.Log("b");
        }
    }

    // 木から落ちる
    public void DownAct()
    {
        Downf = true;
        //重力を起動させる
        rb.useGravity = true;

        Debug.Log("a");
    }
}
