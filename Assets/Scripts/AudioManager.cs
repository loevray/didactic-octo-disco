using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : Singleton<GameManager>
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static AudioManager instance;

    [Header("#BGM")]
    public AudioClip bgmClip;
    public float bgmVolume;
    AudioSource bgmPlayer;

    [Header("#SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels;
    AudioSource[] sfxPlayer;
    int channeIndex;

    public enum Sfx
    {
        OceanEnemyDeath,
        ShootNormalWeapon,
        ShootStrongWeapon,
        ShootSummonsWeapon,
        GetExpOrb
    }

    protected override void Awake()
    {
        instance = this;
        init();
    }

    void init()
    {
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;

        GameObject sfxObject = new GameObject("SfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayer = new AudioSource[channels];

        for (int index = 0; index < sfxPlayer.Length; index++)
        {
            sfxPlayer[index] = sfxObject.AddComponent<AudioSource>();
            sfxPlayer[index].playOnAwake = false;
            sfxPlayer[index].volume = sfxVolume;
        }
    }

    public void PlaySfx(Sfx sfx)
    {
        for (int index = 0; index < sfxPlayer.Length; index++)
        {
            int loopIndex = (index + channeIndex) % sfxPlayer.Length;

            if (sfxPlayer[loopIndex].isPlaying)
            {
                continue;
            }

            channeIndex = loopIndex;
            sfxPlayer[loopIndex].clip = sfxClips[(int)sfx];
            sfxPlayer[loopIndex].Play();
            break;
        }

    }
}
