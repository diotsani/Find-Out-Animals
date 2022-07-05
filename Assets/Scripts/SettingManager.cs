using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    [Header("GammeObject")]
    public GameObject panelSetting;
    public GameObject panelCredit;

    [Header("Tombol")]
    public Button settingBtn;
    public Button quitBtn;
    public Button backBtn;
    public Button creditBtn;
    public Button closeCreditBtn;
    public Button musicBtnOn;
    public Button musicBtnOff;

    [Header("Music")]
    public bool musicOn;
    public bool musicOff;

    public void Awake()
    {
        musicOn = UserDataManager.Progress.musicON;
        musicOff = UserDataManager.Progress.musicOFF;
    }
    void Start()
    {
        

        panelSetting.SetActive(false);

        settingBtn.onClick.AddListener(SettingGame);
        quitBtn.onClick.AddListener(quitGame);
        backBtn.onClick.AddListener(BackGame);
        creditBtn.onClick.AddListener(CreditGame);
        closeCreditBtn.onClick.AddListener(CreditGameClose);

        musicBtnOn.onClick.AddListener(MusicONBtn);
        musicBtnOff.onClick.AddListener(MusicOffBtn);
    }

    void Update()
    {
        IconMusic();
    }

    public void SettingGame()
    {
        panelSetting.SetActive(true);
        Debug.Log("buka pengaturan permainan");
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Keluar dari permainan");
    }

    public void BackGame()
    {
        panelSetting.SetActive(false);
        UserDataManager.Save();
        Debug.Log("kembali ke permainan");
    }
    public void CreditGame()
    {
        panelCredit.SetActive(true);
        Debug.Log("credit terbuka");
    }
    public void CreditGameClose()
    {
        panelCredit.SetActive(false);
        Debug.Log("credit tertutup");
    }

    public void MusicONBtn()
    {
        musicOn = false;
        musicOff = true;
        AudioListener.pause = true;
        UserDataManager.Progress.musicON = false;
        UserDataManager.Progress.musicOFF = true;
        
        
        //musicBtnOn.gameObject.SetActive(false);
        //musicBtnOff.gameObject.SetActive(true);

        Debug.Log("Music on clicked");
    }
    public void MusicOffBtn()
    {
        musicOn = true;
        musicOff = false;
        AudioListener.pause = false;
        UserDataManager.Progress.musicON = true;
        UserDataManager.Progress.musicOFF = false;

        //musicBtnOn.gameObject.SetActive(true);
        //musicBtnOff.gameObject.SetActive(false);

        Debug.Log("Music off clicked");
    }

    public void IconMusic()
    {
        if (musicOn == true)
        {
            musicBtnOn.gameObject.SetActive(true);
            //musicBtnOff.gameObject.SetActive(false);
        }
        else
            musicBtnOn.gameObject.SetActive(false);

        if (musicOff == true)
        {
            //musicBtnOn.gameObject.SetActive(false);
            musicBtnOff.gameObject.SetActive(true);
        }
        else
            musicBtnOff.gameObject.SetActive(false);
    }
}
