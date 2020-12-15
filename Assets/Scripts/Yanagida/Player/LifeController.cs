using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{
    public GameObject[] playerIcons;

    private int destroyCount = 0;

    [SerializeField]
    private GameObject GameoverObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdatePlayerIcons()
    {

        for (int i = 0; i < playerIcons.Length; i++)
        {
            if (destroyCount <= i)
            {
                playerIcons[i].SetActive(true);
            }
            else
            {
                playerIcons[i].SetActive(false);
            }
        }
    }

    public void Damage()
    {
        destroyCount += 1;
        UpdatePlayerIcons();

        if(destroyCount == playerIcons.Length)
        {
            Gameover();
            Debug.Log("g");
        }
        Debug.Log("g");
    }

    private void Gameover()
    {
        GameoverObj.SetActive(true);
        
        
    }

    private void NextScene()
    {
        SceneManager.LoadScene("Title");         // シーン遷移
    }
}
