using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObjController : MonoBehaviour
{
    // オーディオ変数
    AudioSource audioSource;
    [SerializeField]
    private List<AudioClip> audioClip = new List<AudioClip>();

    
    [SerializeField]
    private bool eatflag;   // 捕食フラグ

    // マウス情報
    private GameObject mousemanager;
    private LockCursor lockcursor;

    // プレイヤー情報
    private GameObject Player;
    private PlayerController playerconroller;

    [SerializeField]
    private Vector3 MovePos;

    [SerializeField]
    private GameObject oncursortex;


    // Start is called before the first frame update
    void Start()
    {
        //MyObj = this.gameObject;

        audioSource = gameObject.AddComponent<AudioSource>();
        Player = GameObject.Find("MotionPlayer");
        playerconroller = Player.GetComponent<PlayerController>();
        mousemanager = GameObject.Find("MouseManager");
        lockcursor = mousemanager.GetComponent<LockCursor>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void GetActive()
    {
        // クリック入力を一時停止
        lockcursor.ClickOff();

        // プレイヤーの目的地を設定
        playerconroller.SetMove(MovePos);
        //playerconroller.SetMove(MovePos, MyObj);

        // コルーチン呼び出し
        StartCoroutine("LateActive");
    }

    IEnumerator LateActive()    // プレイヤー移動後に実行
    {
        //～秒停止(プレイヤーが移動してるか否かによって変わる)
        yield return new WaitForSeconds(playerconroller.GetMove());

        // プレイヤーが目的地に着いたら効果音再生
        if (audioClip[0] != null)
        {
            audioSource.PlayOneShot(audioClip[0]);
        }

        // クリック入力可能にする
        lockcursor.ClickOn();
    }

    public void OnCursor()
    {
        oncursortex.SetActive(true);
    }

    public void OutCursor()
    {
        oncursortex.SetActive(false);
    }
}
