using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public GameObject[] playerIcons;

    private int destroyCount = 0;
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
    }
}
