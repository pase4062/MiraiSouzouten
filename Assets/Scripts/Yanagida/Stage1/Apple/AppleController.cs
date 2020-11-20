using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    // オーディオ変数
    AudioSource audioSource;
    [SerializeField]
    private List<AudioClip> audioClip = new List<AudioClip>();

    // private変数
    private bool Downf;         // 落下フラグ
    private bool Rollf;         // 
    private bool Eatf;          // 捕食可能フラグ

    private Rigidbody2D rb;       // 重力変数

    private int eventCnt;

    

    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        eventCnt = 0;

        Downf = false;
        Rollf = false;

        //Rigidbodyを取得
        rb = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -3.0f && eventCnt == 0)
        {
            //重力を停止させる
            //rb.useGravity = false;
            rb.velocity = Vector2.zero;

            Downf = false;

            eventCnt++;
        }

        if (transform.position.x < -5.0f && eventCnt == 1)
        {

            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0.0f;
            eventCnt++;
        }
    }

    // 木から落ちる
    public void DownAct()
    {
        if (!Downf && eventCnt == 0)
        {
            Downf = true;
            //重力を起動させる
            Vector2 myGravity = new Vector2(0, -5.0f);
            //Vector3 force = new Vector3(0.0f, -1.0f, 0.0f);  // 力を設定
            rb.AddForce(myGravity, ForceMode2D.Impulse);          // 力を加える

            Debug.Log("Down");
        }
    }

    public void RollAct()
    {
        if (!Rollf && eventCnt == 1)
        {
            Rollf = true;
            

            Vector2 force = new Vector2(-3.0f, -2.0f);  // 力を設定
            rb.AddForce(force, ForceMode2D.Impulse);          // 力を加える

            float torque = 3.0f;  // 力を設定
            rb.AddTorque(torque, ForceMode2D.Impulse);          // 力を加える
            Debug.Log("Roll");
        }
    }

    public void SetRoll()
    {
        //Rollf = true;
    }

    public void EatAct()
    {
        if (eventCnt == 2)
        {
            // 捕食アクション
            audioSource.PlayOneShot(audioClip[0]);
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
            Debug.Log("Eat");
        }
    }

}
