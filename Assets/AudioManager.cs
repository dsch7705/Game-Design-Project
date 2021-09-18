using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager current;
    private AudioSource source;

    [Range(0.0f, 100.0f)]
    public float volume = 100f;

    // Start is called before the first frame update
    void Start()
    {
        current = this;

        source = gameObject.AddComponent<AudioSource>();

        GameEvents.current.AudioManagerReady();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClip(AudioClip clip)
    {
        source.PlayOneShot(clip, volume / 100);
    }

    public void PlayRandomClip(List<AudioClip> clips)
    {
        int rand = Random.Range(0, clips.Count);
        source.PlayOneShot(clips[rand], volume / 100);
    }
}
