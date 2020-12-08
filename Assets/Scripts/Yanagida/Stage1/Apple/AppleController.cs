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

    // プレイヤー情報
    private GameObject Player;
    private PlayerController playerconroller;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        eventCnt = 0;

        Downf = false;
        Rollf = false;

        //Rigidbodyを取得
        rb = GetComponent<Rigidbody2D>();

        Player = GameObject.Find("MotionPlayer");
        playerconroller = Player.GetComponent<PlayerController>();
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
        // コルーチン呼び出し
        StartCoroutine("Down");
    }

    IEnumerator Down()    // プレイヤー移動後に実行
    {
        //～秒停止(プレイヤーが移動してるか否かによって変わる)
        yield return new WaitForSeconds(playerconroller.GetMove());

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
        // コルーチン呼び出し
        StartCoroutine("Roll");
    }

    IEnumerator Roll()    // プレイヤー移動後に実行
    {
        //～秒停止(プレイヤーが移動してるか否かによって変わる)
        yield return new WaitForSeconds(playerconroller.GetMove());

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

    

    public void EatAct()
    {
        // コルーチン呼び出し
        StartCoroutine("Eat");
    }

    IEnumerator Eat()    // プレイヤー移動後に実行
    {
        //～秒停止(プレイヤーが移動してるか否かによって変わる)
        yield return new WaitForSeconds(playerconroller.GetMove());

        if (eventCnt == 2)
        {
            // 捕食アクション
            //audioSource.PlayOneShot(audioClip[0]);
            // オーディオを再生
            AudioSource.PlayClipAtPoint(audioClip[0], transform.position, 1.0f);
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
            Debug.Log("Eat");
        }
    }

}
