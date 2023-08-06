using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource Audio;
    public AudioSource AudioMove;
    public AudioSource AudioEerie;
    public AudioSource AudioTimer;

    public AudioClip ButtonClick;
    public AudioClip Move;
    public AudioClip Hold;
    public AudioClip Switch;
    public AudioClip Eerie1;
    public AudioClip Eerie2;
    public AudioClip Ghost;
    public AudioClip Beep;

    public static SFXManager SFXInstance;

    private void Awake()
    {
        if (SFXInstance != null && SFXInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        SFXInstance = this;
        DontDestroyOnLoad(this);

    }

    public void playSFX(AudioClip audio)
    {
        if (audio == SFXManager.SFXInstance.Ghost)
            SFXManager.SFXInstance.Audio.panStereo = Random.Range(-1.0f, 1.0f);
        else
            SFXManager.SFXInstance.Audio.panStereo = 0;

        SFXManager.SFXInstance.Audio.volume = 1.0f;
        SFXManager.SFXInstance.Audio.pitch = 1.0f;
        SFXManager.SFXInstance.Audio.PlayOneShot(audio);
    }
    public void playSFXTimerHalf()
    {
        SFXManager.SFXInstance.AudioTimer.volume = 1.0f;
        SFXManager.SFXInstance.AudioTimer.pitch = 0.8f;
        SFXManager.SFXInstance.AudioTimer.PlayOneShot(Beep);
    }
    public void playSFXTimerOne()
    {
        SFXManager.SFXInstance.AudioTimer.volume = 1.0f;
        SFXManager.SFXInstance.AudioTimer.pitch = 1.5f;
        SFXManager.SFXInstance.AudioTimer.PlayOneShot(Beep);
    }

    public void playMove()
    {
        SFXManager.SFXInstance.AudioMove.volume = Random.Range(0.8f, 1.0f);
        SFXManager.SFXInstance.AudioMove.pitch = Random.Range(0.8f, 1.0f);
        SFXManager.SFXInstance.AudioMove.PlayOneShot(SFXManager.SFXInstance.Move);
    }
    public void playEerie()
    {
        float rnd = Random.Range(0.8f, 1.0f);
        SFXManager.SFXInstance.AudioEerie.volume = Random.Range(0.5f, 0.7f);
        SFXManager.SFXInstance.AudioEerie.pitch = Random.Range(0.6f, 0.8f);
        if (rnd > 0.9f)
            SFXManager.SFXInstance.AudioEerie.PlayOneShot(SFXManager.SFXInstance.Eerie1);
        else
            SFXManager.SFXInstance.AudioEerie.PlayOneShot(SFXManager.SFXInstance.Eerie2);
    }

    public bool isPlay(AudioClip audio)
    {
        if (SFXManager.SFXInstance.Audio.name == audio.name)
        {
            if (SFXManager.SFXInstance.Audio.isPlaying == true)
                return true;
            else
                return false;
        }
        else
            return false;
    }
    public bool isPlayMove()
    {
        if (SFXManager.SFXInstance.AudioMove.isPlaying == true)
        {
            return true;
        }
        else
            return false;
    }

    public void stopSFX(AudioClip audio)
    {
        if (SFXManager.SFXInstance.Audio.name == audio.name)
        {
            if (SFXManager.SFXInstance.Audio.isPlaying == true)
                SFXManager.SFXInstance.Audio.Stop();
        }
        else if (SFXManager.SFXInstance.AudioMove.name == audio.name)
        {
            if (SFXManager.SFXInstance.AudioMove.isPlaying == true)
                SFXManager.SFXInstance.Audio.Stop();
        }
    }
}
