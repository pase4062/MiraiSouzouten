using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAppleController : MonoBehaviour
{
    private bool movef;            // 移動フラグ
    private bool moveright;       // 移動方向判定
    private Rigidbody2D rb;       // 重力変数
    // Start is called before the first frame update
    void Start()
    {
        moveright = true;
        movef = false;

        //Rigidbodyを取得
        rb = GetComponent<Rigidbody2D>();
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

    public void Move()
    {
        if (!movef)
        {
            movef = true;
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
