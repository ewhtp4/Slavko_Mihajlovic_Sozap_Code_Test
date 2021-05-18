using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudion : MonoBehaviour
{
    public AudioSource buttonSound;
    public void PlaySound()
    {
        buttonSound.Play();
    }
}
