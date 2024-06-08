using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    [SerializeField] public AudioSource audioMusic;
    [SerializeField] public AudioSource audioSFX;
    [SerializeField] public AudioClip[] musicClips;
    [SerializeField] public AudioClip[] sfxClips;


    // Start is called before the first frame update
    void Start()
    {
        PlayMusic("backgroundmusic");
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Make persistent
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

        // Update is called once per frame
        void Update()
    {
        
    }

    public void PlayMusic(string musicName)
    {
        // Find the music clip by name
        AudioClip clip = musicClips.FirstOrDefault(c => c.name == musicName);

        if (clip == null)
        {
            Debug.LogError("Music clip not found: " + musicName);
            return;
        }

        audioMusic.clip = clip;
        audioMusic.Play();
    }

    public void PlaySFX(string soundEffectName)
    {
        // Find the sound effect clip by name
        AudioClip clip = sfxClips.FirstOrDefault(c => c.name == soundEffectName);

        if (clip == null)
        {
            Debug.LogError("Sound effect clip not found: " + soundEffectName);
            return;
        }

        audioSFX.clip = clip;
        audioSFX.PlayOneShot(clip);
    }

    public void SetMusicVolume(float volume)
    {
        audioMusic.volume = volume;
    }
    public void SetSFXVolume(float volume)
    {
        audioSFX.volume = volume;
    }
}
