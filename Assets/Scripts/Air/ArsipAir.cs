using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class ArsipAir : MonoBehaviour
{
    public GameObject panelLockNotif;
    public CanvasGroup canvasMenu;
    
    public Button[] hewanButton;

    public bool[] hewanClick = { false, false, false};
    public bool[] hewanCanvas = { false, false, false };

    [Header("Kunci Arsip Air")]
    public GameObject[] lockAir;
    public bool lockArsipAir0;
    public bool lockArsipAir1;
    public bool lockArsipAir2;

    [Header("Info Button & BG Air")]
    public Button[] infoButtonAir;
    public Image[] bgAir;

    [Header("lumba")]
    public CanvasGroup lumbaCanvas;
    public Image lumbaImage;
    public Button lumbaBack;
    public Text lumbaText;

    [Header("koi")]
    public CanvasGroup koiCanvas;
    public Image koiImage;
    public Button koiBack;
    public Text koiText;

    [Header("paus")]
    public CanvasGroup pausCanvas;
    public Image pausImage;
    public Button pausBack;
    public Text pausText;

    public void Awake()
    {
        lockArsipAir0 = UserDataManager.Progress.lockArsipAir[0];
        lockArsipAir1 = UserDataManager.Progress.lockArsipAir[1];
        lockArsipAir2 = UserDataManager.Progress.lockArsipAir[2];

        if (lockArsipAir0 == false)
        {
            lockAir[0].SetActive(false);
        }

        if (lockArsipAir1 == false)
        {
            lockAir[1].SetActive(false);
        }

        if (lockArsipAir2 == false)
        {
            lockAir[2].SetActive(false);
        }
    }

    void Start()
    {
        //panelLockNotif.SetActive(false);
        hewanButton[0].onClick.AddListener(Hewan0);
        hewanButton[1].onClick.AddListener(Hewan1);
        hewanButton[2].onClick.AddListener(Hewan2);
    }

    void Update()
    {
        if (hewanClick[0] == true) // lumba
        {
            lumbaCanvas.gameObject.SetActive(true);
            koiCanvas.gameObject.SetActive(false);
            pausCanvas.gameObject.SetActive(false);

            lumbaCanvas.DOFade(1f, 0.5f);
            koiCanvas.DOFade(0f, 0.5f);
            pausCanvas.DOFade(0f, 0.5f);

            hewanCanvas[0] = true;
            hewanCanvas[1] = false;
            hewanCanvas[2] = false;

            hewanClick[0] = false;
        }

        if (hewanClick[1] == true) // koi
        {
            lumbaCanvas.gameObject.SetActive(false);
            koiCanvas.gameObject.SetActive(true);
            pausCanvas.gameObject.SetActive(false);

            lumbaCanvas.DOFade(0f, 0.5f);
            koiCanvas.DOFade(1f, 0.5f);
            pausCanvas.DOFade(0f, 0.5f);

            hewanCanvas[0] = false;
            hewanCanvas[1] = true;
            hewanCanvas[2] = false;

            hewanClick[1] = false;
        }

        if (hewanClick[2] == true) // paus
        {
            lumbaCanvas.gameObject.SetActive(false);
            koiCanvas.gameObject.SetActive(false);
            pausCanvas.gameObject.SetActive(true);

            lumbaCanvas.DOFade(0f, 0.5f);
            koiCanvas.DOFade(0f, 0.5f);
            pausCanvas.DOFade(1f, 0.5f);

            hewanCanvas[0] = false;
            hewanCanvas[1] = false;
            hewanCanvas[2] = true;

            hewanClick[2] = false;
        }
    }

    public void CanvasGroup()
    {
        
    }

    public void InfoHewan()
    {
        if(hewanCanvas[0] == true) // lumba
        {
            canvasMenu.DOFade(0f, 0.5f);
            lumbaImage.gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(350f, 350f), 0.5f);
            lumbaImage.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 0.5f);
            //lumbaText.DOFade(0f, 0.5f);
            lumbaBack.gameObject.SetActive(true);

            infoButtonAir[0].gameObject.SetActive(false);
            bgAir[0].gameObject.SetActive(true);
        }

        if (hewanCanvas[1] == true) // koi
        {
            canvasMenu.DOFade(0f, 0.5f);
            koiImage.gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(350f, 350f), 0.5f);
            koiImage.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 0.5f);
            //lumbaText.DOFade(0f, 0.5f);
            koiBack.gameObject.SetActive(true);

            infoButtonAir[1].gameObject.SetActive(false);
            bgAir[1].gameObject.SetActive(true);
        }

        if (hewanCanvas[2] == true) // paus
        {
            canvasMenu.DOFade(0f, 0.5f);
            pausImage.gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(350f, 350f), 0.5f);
            pausImage.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 0.5f);
            //lumbaText.DOFade(0f, 0.5f);
            pausBack.gameObject.SetActive(true);

            infoButtonAir[2].gameObject.SetActive(false);
            bgAir[2].gameObject.SetActive(true);
        }

    }

    public void BackHewan()
    {
        if (hewanCanvas[0] == true) // lumba
        {
            lumbaCanvas.DOFade(0f, 0.5f);
            canvasMenu.DOFade(1f, 0.5f);

            lumbaImage.gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(250f, 250f), 0.5f);
            lumbaImage.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(200, -35), 0.5f);
            lumbaBack.gameObject.SetActive(false);

            hewanCanvas[0] = false;

            infoButtonAir[0].gameObject.SetActive(true);
            bgAir[0].gameObject.SetActive(false);
        }

        if (hewanCanvas[1] == true) // koi
        {
            koiCanvas.DOFade(0f, 0.5f);
            canvasMenu.DOFade(1f, 0.5f);

            koiImage.gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(250f, 250f), 0.5f);
            koiImage.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(200, -35), 0.5f);
            koiBack.gameObject.SetActive(false);

            hewanCanvas[1] = false;

            infoButtonAir[1].gameObject.SetActive(true);
            bgAir[1].gameObject.SetActive(false);
        }

        if (hewanCanvas[2] == true) // paus
        {
            pausCanvas.DOFade(0f, 0.5f);
            canvasMenu.DOFade(1f, 0.5f);

            pausImage.gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(250f, 250f), 0.5f);
            pausImage.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(200, -35), 0.5f);
            pausBack.gameObject.SetActive(false);

            hewanCanvas[2] = false;

            infoButtonAir[2].gameObject.SetActive(true);
            bgAir[2].gameObject.SetActive(false);
        }
    }

    public void Hewan0() // lumba
    {
        hewanClick[0] = true;
        Debug.Log("hewan 0 click");
    }

    public void Hewan1() // koi
    {
        hewanClick[1] = true;
        Debug.Log("hewan 1 click");
    }

    public void Hewan2() // paus
    {
        hewanClick[2] = true;
        Debug.Log("hewan 2 click");
    }

    public void ButtonLock() // Pop up notifikasi terkunci
    {
        panelLockNotif.SetActive(true);
        StartCoroutine(LockNotif(3));
    }

    public  IEnumerator LockNotif(float sec)
    {
        yield return new WaitForSeconds(sec);
        panelLockNotif.SetActive(false);
    }
}
