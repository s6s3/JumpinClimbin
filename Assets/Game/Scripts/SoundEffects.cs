using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundEffects : MonoBehaviour {
    private AudioSource audioSourcePlayer;
    private AudioSource audioSource;
    private AudioSource music;
    public List<AudioClip> audioClips = new List<AudioClip>();

    [SerializeField, Range(0, 1)]
    public float bgmVolume = 1.0f;
    [SerializeField]
    private float fadeOutTime = 2.0f;
    private float t = 0;
    private bool toStop = false;

    void Update()
    {
        if (music.isPlaying && toStop)
        {
            t -= Time.deltaTime / fadeOutTime;
            if (t > 0) music.volume = t * bgmVolume;
            else music.Stop();
        }
    }

    public void init(GameSystem gs)
    {
        PlayerManager player = gs.playerManager;
        GameObject go = player.gameObject;
        audioSourcePlayer = go.AddComponent<AudioSource>();
        audioSourcePlayer.spatialBlend = 1.0f;
        audioSourcePlayer.minDistance = 3;

        audioSource = gameObject.AddComponent<AudioSource>();
        
        music = gameObject.AddComponent<AudioSource>();
        music.clip = audioClips[7];
        music.loop = true;

        player.onCollisionWithJumperExit += (tmp) => {
            Jumper j = tmp.GetComponent<Jumper>();
            if (j.pushForce == 30) OnPowerJump();
            else OnJump();
        };
        gs.checkGameOver.toGameOver += () => { OnFalling(); };
        
    }

    public void OnJump()
    {
        audioSourcePlayer.PlayOneShot(audioClips[Random.Range(0, 3)]);
    }

    public void OnPowerJump()
    {
        audioSourcePlayer.PlayOneShot(audioClips[Random.Range(3, 5)]);
    }

    public void OnFalling()
    {
        audioSourcePlayer.PlayOneShot(audioClips[5]);
    }

    public void OnSelect()
    {
        audioSource.PlayOneShot(audioClips[6], 0.3f);
    }

    public void PlayBGM()
    {
        music.Stop();
        music.volume = bgmVolume;
        music.Play();
        t = 1;
        toStop = false;
    }

    public void StopBGM()
    {
        if (fadeOutTime == 0) music.Stop();
        else toStop = true;
    }
}
