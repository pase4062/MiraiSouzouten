﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    // オーディオ変数
    AudioSource audioSource;
    [SerializeField]
    private List<AudioClip> audioClip = new List<AudioClip>();

    private bool disturbflug;       // お邪魔フラグ
    private bool move;       // お邪魔フラグ
    Vector3 redirection = new Vector3(7f, 0.9f, 0f);      // デフォルト位置
    Vector3 direction = new Vector3(7f, -2.5f, 0f);      // デフォルト位置

    [SerializeField]
    private float Downspeed = 1.5f;
    [SerializeField]
    private float Upspeed = 1.5f;

    [SerializeField]
    private GameObject BugApple;
    BugAppleController bugapplecontroller;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        disturbflug = false;
        move = true;

        bugapplecontroller = BugApple.GetComponent<BugAppleController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(disturbflug)
        {
            if(move)
            {
                float step = Downspeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, direction, step);

                if (transform.position == direction)
                {
                    move = false;
                    // 虫食いリンゴが右にあればゴールフラグが経つ
                    if (!bugapplecontroller.GetApple())
                    {
                        disturbflug = false;
                        //DelayMethodを3秒後に呼び出す
                        Invoke("NextScene", 3.0f);
                        
                    }

                }
            }
            else
            {
                float step = Upspeed * Time.deltaTime;
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
        audioSource.PlayOneShot(audioClip[0]);

        disturbflug = true;
        Debug.Log("spider");
    }

    private void NextScene()
    {
        FadeManager.Instance.LoadScene("Stage2_2", 2.0f);
        Debug.Log("Stage2Go");
    }
}
