using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.A))
        //{
        //    FadeManager.Instance.LoadScene("PrototypeStage1", 2.0f);
        //}
    }

    public void PlayGame()
    {
        FadeManager.Instance.LoadScene("PrototypeStage1", 2.0f);
    }
}
