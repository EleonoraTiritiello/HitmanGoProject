using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    private AudioSource source;
    public string clipName;
    public AudioClip clip;
    [Range(0f, 2f)]
    public float volume;
    [Range(0f, 2f)]
    public float pitch;
    public bool loop;
    public bool playOnAwake;
    public AudioMixerGroup mixer;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = this.clip;
        source.volume = this.volume;
        source.pitch = this.pitch;
        source.loop = this.loop;
        source.playOnAwake = this.playOnAwake;
        source.outputAudioMixerGroup = this.mixer;
    }

    public void PlayAudio()
    {
        source.Play();
    }

    public void StopAudio()
    {
        source.Stop();
    }

    public void PauseAudio()
    {
        source.Pause();
    }

    public void UnpauseAudio()
    {
        source.UnPause();
    }

}


public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField]
    private Sound[] sounds;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject soundObj = new GameObject("Sound_" + i + sounds[i].clipName);
            soundObj.transform.SetParent(this.transform);
            sounds[i].SetSource(soundObj.AddComponent<AudioSource>());
        }
    }

    public void PlaySound(string name)
    {
        Sound s = SearchSound(name);
        s.PlayAudio();
    }

    public void StopSound(string name)
    {
        Sound s = SearchSound(name);
        s.StopAudio();
    }

    public void ResumeSound(string name)
    {
        Sound s = SearchSound(name);
        s.StopAudio();
    }

    public void PauseSound(string name)
    {
        Sound s = SearchSound(name);
        s.PauseAudio();
    }

    public void UnpauseSound(string name)
    {
        Sound s = SearchSound(name);
        s.UnpauseAudio();
    }

    private Sound SearchSound(string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (name == sounds[i].clipName)
            {
                return sounds[i];
            }
        }
        return null;
    }
}
