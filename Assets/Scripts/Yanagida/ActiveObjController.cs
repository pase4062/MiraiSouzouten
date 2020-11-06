﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObjController : MonoBehaviour
{
    // オーディオ変数
    AudioSource audioSource;
    [SerializeField]
    private List<AudioClip> audioClip = new List<AudioClip>();

    
    [SerializeField]
    private bool Actflag;   // ゲーム進行フラグ
    private bool goalflag;  // ゴール判定フラグ

    [SerializeField]
    private GameObject NextObj;                     // 次に動かすオブジェクト
    private ActiveObjController NextController;     // 次に動かすオブジェクトスクリプト

    [SerializeField]
    GameObject apple;
    private AppleController appleController;     // 次に動かすオブジェクトスクリプト
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        if(NextObj)
            NextController = NextObj.GetComponent<ActiveObjController>();
        
        if(apple)
            appleController = apple.GetComponent<AppleController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void ActflagOn()
    {
        Actflag = true;
    }

    public void GetActive()
    {
        // フラグが立っていればギミックが動く(リンゴが落ちるなどの)
        if (Actflag)
        {

            // 一回のみ反応
            Actflag = false;
            if (apple)
            {
                appleController.DownAct();
            }



            // 次に反応するオブジェクトのフラグを立てる
            NextController.ActflagOn();
        }
        else if(this.gameObject.tag == "Finish")
        {
            if(goalflag)    // ゴール可能か
            {
                // 次のシーンへ飛ぶかステージクリア演出の表示
                Debug.Log("くりあ！！");
            }
            else // ステージごとにゴール阻害するものが変わるため書き直しそう(ステージ1では蜘蛛が邪魔してくる)
            {

            }
        }
        else
        {
            // 反応なしSE再生
            audioSource.PlayOneShot(audioClip[0]);
        }
    }
}