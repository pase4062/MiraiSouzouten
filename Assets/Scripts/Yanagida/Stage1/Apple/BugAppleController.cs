using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAppleController : MonoBehaviour
{
    private bool movef;            // 移動フラグ
    private bool moveright;       // 移動方向判定
    private Rigidbody2D rb;       // 重力変数

    // プレイヤー情報
    private GameObject Player;
    private PlayerController playerconroller;

    [SerializeField]
    private GameObject Goal;
    private GoalObject Goalconroller;
    // Start is called before the first frame update
    void Start()
    {
        moveright = true;
        movef = false;

        //Rigidbodyを取得
        rb = GetComponent<Rigidbody2D>();

        Player = GameObject.Find("MotionPlayer");
        playerconroller = Player.GetComponent<PlayerController>();

        Goalconroller = Goal.GetComponent<GoalObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(movef)
        {
            if(transform.position.x < 4.0f && !moveright)
            {
                StopMove();
                moveright = true;

            }
            else if(transform.position.x > 6.5f && moveright)
            {
                StopMove();
                moveright = false;
            }
        }
    }

    public void MoveAct()
    {
        // コルーチン呼び出し
        StartCoroutine("Move");
    }

    IEnumerator Move()
    {
        //～秒停止(プレイヤーが移動してるか否かによって変わる)
        yield return new WaitForSeconds(playerconroller.GetMove());

        if (!movef)
        {
            movef = true;
            Goalconroller.FlagChange(); // ゴールフラグ切り替え

            if (moveright)
            {
                Vector2 force = new Vector2(3.0f, 0.0f);  // 力を設定
                rb.AddForce(force, ForceMode2D.Impulse);          // 力を加える

                float torque = -1.0f;  // 力を設定
                rb.AddTorque(torque, ForceMode2D.Impulse);          // 力を加える
            }
            else
            {
                Vector2 force = new Vector2(-3.0f, 0.0f);  // 力を設定
                rb.AddForce(force, ForceMode2D.Impulse);          // 力を加える

                float torque = 1.0f;  // 力を設定
                rb.AddTorque(torque, ForceMode2D.Impulse);          // 力を加える
            }
        }
    }

    private void StopMove()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0.0f;
        movef = false;
    }

    public bool GetApple()
    {
        return moveright;
    }
}
