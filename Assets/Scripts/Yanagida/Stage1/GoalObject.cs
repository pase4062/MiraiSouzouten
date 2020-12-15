using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalObject : MonoBehaviour
{
    [SerializeField]
    private bool goalflag;  // ゴール判定フラグ

    [SerializeField]
    private GameObject Spider;                     // 蜘蛛オブジェクト
    private SpiderController spidercontroller;     // 蜘蛛スクリプト

    private GameObject Player;
    private PlayerController playerconroller;

    [SerializeField]
    private Vector3 MovePos;

    [SerializeField]
    private Vector3 BadPos;

    // マウス情報
    private GameObject mousemanager;
    private LockCursor lockcursor;

    [SerializeField]
    private GameObject oncursortex;
    // Start is called before the first frame update
    void Start()
    {
        //goalflag = false;
        Player = GameObject.Find("MotionPlayer");
        playerconroller = Player.GetComponent<PlayerController>();

        if (Spider)
            spidercontroller = Spider.GetComponent<SpiderController>();

        mousemanager = GameObject.Find("MouseManager");
        lockcursor = mousemanager.GetComponent<LockCursor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetActive()
    {
        if (goalflag)    // ゴール可能か
        {
            // プレイヤーの目的地を設定
            playerconroller.SetMove(MovePos);
            spidercontroller.Disturb();
            
        }
        else // ステージごとにゴール阻害するものが変わるため書き直しそう(ステージ1では蜘蛛が邪魔してくる)
        {
            // プレイヤーの目的地を設定
            playerconroller.SetMove(BadPos);
            spidercontroller.Disturb();
        }
    }

   
    void NextScene()
    {
        SceneManager.LoadScene("Stage2_1");         // シーン遷移
    }

    public void FlagChange()
    {
        goalflag = !goalflag;
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
