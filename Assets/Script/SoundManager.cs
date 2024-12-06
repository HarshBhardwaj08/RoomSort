using UnityEngine;
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource clickSound; 
    public AudioSource winSound;   
    public AudioSource lostSound;  

    public void SetSound(bool isSoundOn)
    {
        if (clickSound != null) clickSound.mute = !isSoundOn;
        if (winSound != null) winSound.mute = !isSoundOn;
        if (lostSound != null) lostSound.mute = !isSoundOn;
    }

    public void PlayClickSound()
    {
        if (clickSound != null && !clickSound.mute)
            clickSound.Play();
    }

    public void PlayWinSound()
    {
        if (winSound != null && !winSound.mute)
            winSound.Play();
    }

    public void PlayLostSound()
    {
        if (lostSound != null && !lostSound.mute)
            lostSound.Play();
    }
}

