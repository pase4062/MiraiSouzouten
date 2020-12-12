using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cocoon : MonoBehaviour
{
    private Renderer renderer;
    private Color color;
    private float nextTime;
    public float interval = 1.0f;	// 点滅周期

    public int destroyCount = 0;

    // プレイヤー情報
    private GameObject Player;
    private PlayerController playerconroller;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("MotionPlayer");
        playerconroller = Player.GetComponent<PlayerController>();

        renderer = this.GetComponent<Renderer>();
        color = gameObject.GetComponent<Renderer>().material.color;
        color.a = 0.0f;
        gameObject.GetComponent<Renderer>().material.color = color;
        nextTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {

        

        if(color.a < 1.0f)
        {
            color.a += 0.03f;
            gameObject.GetComponent<Renderer>().material.color = color;
            if (color.a > 1.0f)
                Invoke("CocoonPlayer", 1);
        }
        
        //if (Time.time > nextTime)
        //{
        //    renderer.enabled = !renderer.enabled;
        //
        //    nextTime += interval;
        //}

    }

    private void CocoonPlayer()
    {
        color.a = 0.0f;
        gameObject.GetComponent<Renderer>().material.color = color;

        playerconroller.Respown();

        gameObject.SetActive(false);
    }
}
