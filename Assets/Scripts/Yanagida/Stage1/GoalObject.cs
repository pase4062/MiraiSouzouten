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

    // Start is called before the first frame update
    void Start()
    {
        //goalflag = false;

        if (Spider)
            spidercontroller = Spider.GetComponent<SpiderController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetActive()
    {
        if (goalflag)    // ゴール可能か
        {
            // 次のシーンへ飛ぶかステージクリア演出の表示
            Debug.Log("くりあ！！");
            NextScene();
        }
        else // ステージごとにゴール阻害するものが変わるため書き直しそう(ステージ1では蜘蛛が邪魔してくる)
        {
            spidercontroller.Disturb();
        }
    }

    public void GoalTrue()
    {
        goalflag = true;
    }

    void NextScene()
    {
        SceneManager.LoadScene("Stage2");         // シーン遷移
    }
}
