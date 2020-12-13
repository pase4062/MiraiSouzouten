using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;

    // 移動用変数
    [SerializeField, Range(1, 5)]
    private float time = 1;                         // 移動にかかる時間
    private Vector3 startposition, endposition;     // 移動開始時地点と目的地
    private float startTime;                        // 移動開始時間

    //　移動速度
    [SerializeField]
    private float speed;
    private bool movef;
    private Vector2 scale;

    // 初期位置
    private Vector2 sposition;

    //private GameObject ActObj;      // 移動後にアクティブにするオブジェクト
    private GameObject LifeUI;
    private UIManager uimanager;

    private bool evomode;
    [SerializeField]
    private float interval = 1.0f;	// 点滅周期
    private float nextTime;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        movef = false;
        scale = transform.localScale;

        sposition = transform.position;

        LifeUI = GameObject.Find("UIManager");
        uimanager = LifeUI.GetComponent<UIManager>();

        evomode = false;
        nextTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if(movef)
        {
            // 移動方法修正後
            var diff = Time.timeSinceLevelLoad - startTime;
            if(diff > time)
            {
                transform.position = endposition;
                movef = false;

                anim.SetTrigger("Move to Wait");
                
                scale.x = 0.5f;
                transform.localScale = scale;
            }
            var rate = diff / time;

            transform.position = Vector3.Lerp(startposition, endposition, rate);

            // 移動方法修正前
            //float step = speed * Time.deltaTime;
            //transform.position = Vector3.MoveTowards(transform.position, direction, step);
            //
            //if(transform.position == direction)
            //{
            //    anim.SetTrigger("Move to Wait");
            //    movef = false;
            //
            //    scale.x = 0.5f;
            //    transform.localScale = scale;
            //
            //    // ここから行動関数？
            //}

        
        }

        if(evomode)
        {
            if (Time.time > nextTime)
            {
                //renderer.enabled = !renderer.enabled;
            
                nextTime += interval;
            }

            // 一定フレームで進化し第二形態へ
            evomode = false;
            anim.speed = 1;
            //anim.SetTrigger("Move to Wait");
        }

    }

    //public void SetMove(Vector3 destpos, GameObject clickobj)
    public void SetMove(Vector3 destpos)
    {

        // 目的地を設定
        endposition = destpos;

        if (transform.position != endposition)
        {


            if (this.transform.position.x > endposition.x)
            {
                scale.x = -0.5f;
                transform.localScale = scale;
            }
            else
            {
                scale.x = 0.5f;
                transform.localScale = scale;
            }

            // 移動モードに
            anim.SetTrigger("Wait to Move");
            movef = true;

            startTime = Time.timeSinceLevelLoad;
            startposition = transform.position;
        }
    }

    public int GetMove()
    {
        if(movef)
            return 1;
        else
            return 0;
    }

    public void Respown()
    {
        // ライフが1減り初期地へ
        uimanager.Damage();

        transform.position = sposition;
    }

    public void Evolve()
    {
        anim.speed = 0;
        evomode = true;
    }
}
