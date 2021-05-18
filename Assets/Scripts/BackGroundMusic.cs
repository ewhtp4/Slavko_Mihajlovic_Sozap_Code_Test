using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    private static BackGroundMusic backGroundMusic;
    private bool muted = false;

    void Awake()
    {
        if(backGroundMusic == null)
        {
            backGroundMusic = this;
            DontDestroyOnLoad(backGroundMusic);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnButtonPress()
    {
        if(!muted)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
    }
}
