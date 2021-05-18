/*******************************************************
 *          Set's up the Background Music
 ******************************************************/

using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    private static BackGroundMusic backGroundMusic;
    private bool muted = false;

    private void Awake()
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
