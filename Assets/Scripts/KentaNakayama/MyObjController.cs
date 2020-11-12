using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyObjController: MonoBehaviour
{
    // オーディオ変数
    AudioSource audioSource;
    [SerializeField]
    private List<AudioClip> audioClip = new List<AudioClip>();

    private int life;

    private bool Dmgflag;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        life = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetActive()
    {
        if(Dmgflag)
        {
            if(life >= 0)
            {
                life -= 1;
            }
        }
        else
        {
            // 反応なしSE再生
            audioSource.PlayOneShot(audioClip[0]);
        }
    }
}
