using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SoundManager : MonoBehaviour
{
    public bool musicIsOn;
    public GameObject[] thisObj;

    [Header("Background Music")]
    [SerializeField] AudioClip[] bgmSounds;
    AudioSource myAudioSource;

    [Header("Button SFX")]
    [SerializeField] AudioClip buttonSounds;
    AudioSource myAudioButton;

    public void Awake()
    {
        thisObj = GameObject.FindGameObjectsWithTag("SoundManager");
        if (thisObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

    }

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        myAudioButton = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (UserDataManager.Progress.musicON)
        {
            if (!myAudioSource.isPlaying)
            {
                Bgm();
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.currentSelectedGameObject != null)
                {
                    if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() != null)
                    {
                        ButtonSfx();
                    }
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void Bgm()
    {
        AudioClip clip = bgmSounds[UnityEngine.Random.Range(0, bgmSounds.Length)];
        myAudioSource.PlayOneShot(clip, 0.75f);
    }

    public void ButtonSfx()
    {
        AudioClip buttonClip = buttonSounds;
        myAudioButton.PlayOneShot(buttonClip);
    }
}
