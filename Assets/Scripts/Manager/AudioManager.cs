using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Default Music")]
    [SerializeField] private AudioClip defaultMusicClip;

    [Header("Default SFX")]
    [SerializeField] private AudioClip numberChangeClip1;
    [SerializeField] private AudioClip numberChangeClip2;
    [SerializeField] private AudioClip numberChangeClipSick;
    [SerializeField] private AudioClip knockDoorClip1;
    [SerializeField] private AudioClip knockDoorClip2;

    private void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // ---------- MUSIC ----------
    public void PlayMusic(AudioClip clip, bool loop = true)
    {
        if (clip == null) return;

        musicSource.clip = clip;
        musicSource.loop = loop;
        musicSource.Play();
    }

    public void PlayDefaultMusic()
    {
        if (defaultMusicClip == null) return;

        musicSource.clip = defaultMusicClip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    // ---------- SFX ----------
    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;

        sfxSource.PlayOneShot(clip);
    }

    public void StopSFX()
    {
        sfxSource.Stop();
    }

    public void PlayRandomClip(AudioClip clipA, AudioClip clipB)
    {
        if (sfxSource == null || clipA == null || clipB == null)
            return;

        AudioClip chosen = (Random.value < 0.5f) ? clipA : clipB;

        sfxSource.clip = chosen;
        sfxSource.Play();
    }


    // Functions to call specific sounds from anywhere.
    public void PlayRandomClipBingoBall()
    {
        PlayRandomClip(numberChangeClip1, numberChangeClip2);
    }

    public void PlayClipBingoBallSick()
    {
        PlaySFX(numberChangeClipSick);
    }

    public void PlayRandomClipKnockDoor()
    {
        PlayRandomClip(knockDoorClip1, knockDoorClip2);
    }
}
