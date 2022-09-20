using UnityEngine;
using UnityEngine.UI;

public class PlayMenuManager : MonoBehaviour
{
    [Header("Button")]
    public Button tutorialButton;
    public Button closeButton;
    public GameObject tutorialPanel;
    [Header("Jawaban Darat")]
    public GameObject[] starsDarat;
    public bool jawabanBenarDarat0;
    public bool jawabanBenarDarat1;
    public bool jawabanBenarDarat2;

    [Header("Jawaban Air")]
    public GameObject[] starsDaratAir;
    public bool[] jawabanBenarAir = { false, false, false };

    [Header("Jawaban Udara")]
    public GameObject[] starsDaratUdara;
    public bool[] jawabanBenarUdara = { false, false, false };

    public void Awake()
    {
        tutorialButton.onClick.AddListener(() => SetTutorialButton(true));
        closeButton.onClick.AddListener(() => SetTutorialButton(false));
        //---------------------------------------------------------------------DARAT
        jawabanBenarDarat0 = UserDataManager.Progress.jawabanBenarDarat[0];
        jawabanBenarDarat1 = UserDataManager.Progress.jawabanBenarDarat[1];
        jawabanBenarDarat2 = UserDataManager.Progress.jawabanBenarDarat[2];

        if (jawabanBenarDarat0 == true)
        {
            starsDarat[0].SetActive(true);
        }

        if (jawabanBenarDarat1 == true)
        {
            starsDarat[1].SetActive(true);
        }

        if (jawabanBenarDarat2 == true)
        {
            starsDarat[2].SetActive(true);
        }

        //---------------------------------------------------------------------AIR
        jawabanBenarAir[0] = UserDataManager.Progress.jawabanBenarAir[0];
        jawabanBenarAir[1] = UserDataManager.Progress.jawabanBenarAir[1];
        jawabanBenarAir[2] = UserDataManager.Progress.jawabanBenarAir[2];

        if (jawabanBenarAir[0] == true)
        {
            starsDaratAir[0].SetActive(true);
        }
        if (jawabanBenarAir[1] == true)
        {
            starsDaratAir[1].SetActive(true);
        }
        if (jawabanBenarAir[2] == true)
        {
            starsDaratAir[2].SetActive(true);
        }

        //---------------------------------------------------------------------UDARA
        jawabanBenarUdara[0] = UserDataManager.Progress.jawabanBenarUdara[0];
        jawabanBenarUdara[1] = UserDataManager.Progress.jawabanBenarUdara[1];
        jawabanBenarUdara[2] = UserDataManager.Progress.jawabanBenarUdara[2];

        if (jawabanBenarUdara[0] == true)
        {
            starsDaratUdara[0].SetActive(true);
        }

        if (jawabanBenarUdara[1] == true)
        {
            starsDaratUdara[1].SetActive(true);
        }

        if (jawabanBenarUdara[2] == true)
        {
            starsDaratUdara[2].SetActive(true);
        }
    }
    void SetTutorialButton(bool GetBool)
    {
        tutorialPanel.SetActive(GetBool);
    }
}
