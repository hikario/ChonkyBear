using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixerSnapshot normal;
    public AudioMixerSnapshot excitement;
    public AudioMixerSnapshot calm;
    public AudioMixerSnapshot woodFootsteps;
    public AudioMixer musicVolume;
    public AudioMixer sfxVolume;

    public bool calmSwitch = false;
    public float fadeTime = 1f;
    public AudioClip otherClip;

    //public AudioSource[] efxSource;                   //Drag a reference to the audio source which will play the sound effects.
    public AudioSource efxSource;                   //Drag a reference to the audio source which will play the sound effects.
    public AudioSource musicSource;                 //Drag a reference to the audio source which will play the music.
    public static AudioManager instance = null;     //Allows other scripts to call functions from SoundManager.             
    public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
    public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.


    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
        calmSwitch = false;
    }



    void Update ()
    {
        if (Input.GetKeyDown("1"))
        {
            calm.TransitionTo(fadeTime);
        }
        else if (Input.GetKeyDown("2"))
        {
            normal.TransitionTo(fadeTime);
        }
        else if (Input.GetKeyDown("3"))
        {
            excitement.TransitionTo(fadeTime);
        }
    }



    public void SetSfxLvl(float sfxLvl)
    {
        sfxVolume.SetFloat("sfxVolume", sfxLvl);
    }
    public void SetMusicLvl(float musicLvl)
    {
        musicVolume.SetFloat("musicVolume", musicLvl);
    }




    //Used to play single sound clips.
    public void PlaySingle(AudioClip clip)
    {
        if (!efxSource.isPlaying)//this magically checks if the audio source is already playing something...MAGIC
        {
            //Set the clip of our efxSource audio source to the clip passed in as a parameter.
            efxSource.clip = clip;

            //Play the clip.
            efxSource.Play();
        }

    }



    //RandomizeSfx chooses randomly between various audio clips and slightly changes their pitch.
    public void RandomizeSfx(params AudioClip[] clips)
    {
        //Generate a random number between 0 and the length of our array of clips passed in.
        int randomIndex = Random.Range(0, clips.Length);

        //Choose a random pitch to play back our clip at between our high and low pitch ranges.
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        //Set the pitch of the audio source to the randomly chosen pitch.
        efxSource.pitch = randomPitch;

        //Set the clip to the clip at our randomly chosen index.
        efxSource.clip = clips[randomIndex];

        //Play the clip.
        efxSource.Play();
    }
}