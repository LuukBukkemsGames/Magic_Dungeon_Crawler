using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    public AudioSource SoundClip1;
    public AudioSource SoundClip2;
    public AudioSource SoundClip3;

    private AudioSource[] AudioClips;

    public float Volume;

    private int PlayingClip;

	void Start () {

        Volume = 50;

        AudioClips = new AudioSource[3];
        AudioClips[0] = SoundClip1;
        AudioClips[1] = SoundClip2;
        AudioClips[2] = SoundClip3;

        for (int i = 0; i < 3; i++)
            AudioClips[i].volume = Volume / 100;

        PlayRandomSong();
    }	

    void Update()
    {
        if(!AudioClips[PlayingClip].isPlaying)
        {
            PlayRandomSong();
        }
    }

    void PlayRandomSong()
    {
        PlayingClip = Random.Range(0, 2);
        AudioClips[PlayingClip].Play();
    }
}
