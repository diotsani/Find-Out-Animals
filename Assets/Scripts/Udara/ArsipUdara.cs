using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class ArsipUdara : MonoBehaviour
{
    public GameObject panelLockNotif;
    public CanvasGroup canvasMenu;
    
    public Button[] hewanButton;

    public bool[] hewanClick = { false, false, false};
    public bool[] hewanCanvas = { false, false, false };

    [Header("Kunci Arsip Udara")]
    public GameObject[] lockUdara;
    public bool lockArsipUdara0;
    public bool lockArsipUdara1;
    public bool lockArsipUdara2;

    [Header("Info Button & BG Udara")]
    public Button[] infoButtonUdara;
    public Image[] bgUdara;

    [Header("kakatua")]
    public CanvasGroup kakatuaCanvas;
    public Image kakatuaImage;
    public Button kakatuaBack;
    public Text kakatuaText;

    [Header("merak")]
    public CanvasGroup merakCanvas;
    public Image merakImage;
    public Button merakBack;
    public Text merakText;

    [Header("merpati")]
    public CanvasGroup merpatiCanvas;
    public Image merpatiImage;
    public Button merpatiBack;
    public Text merpatiText;

    public void Awake()
    {
        lockArsipUdara0 = UserDataManager.Progress.lockArsipUdara[0];
        lockArsipUdara1 = UserDataManager.Progress.lockArsipUdara[1];
        lockArsipUdara2 = UserDataManager.Progress.lockArsipUdara[2];

        if (lockArsipUdara0 == false)
        {
            lockUdara[0].SetActive(false);
        }

        if (lockArsipUdara1 == false)
        {
            lockUdara[1].SetActive(false);
        }

        if (lockArsipUdara2 == false)
        {
            lockUdara[2].SetActive(false);
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
        if (hewanClick[0] == true) // kakatua
        {
            kakatuaCanvas.gameObject.SetActive(true);
            merakCanvas.gameObject.SetActive(false);
            merpatiCanvas.gameObject.SetActive(false);

            kakatuaCanvas.DOFade(1f, 0.5f);
            merakCanvas.DOFade(0f, 0.5f);
            merpatiCanvas.DOFade(0f, 0.5f);

            hewanCanvas[0] = true;
            hewanCanvas[1] = false;
            hewanCanvas[2] = false;

            hewanClick[0] = false;
        }

        if (hewanClick[1] == true) // merak
        {
            kakatuaCanvas.gameObject.SetActive(false);
            merakCanvas.gameObject.SetActive(true);
            merpatiCanvas.gameObject.SetActive(false);

            kakatuaCanvas.DOFade(0f, 0.5f);
            merakCanvas.DOFade(1f, 0.5f);
            merpatiCanvas.DOFade(0f, 0.5f);

            hewanCanvas[0] = false;
            hewanCanvas[1] = true;
            hewanCanvas[2] = false;

            hewanClick[1] = false;
        }

        if (hewanClick[2] == true) // merpati
        {
            kakatuaCanvas.gameObject.SetActive(false);
            merakCanvas.gameObject.SetActive(false);
            merpatiCanvas.gameObject.SetActive(true);

            kakatuaCanvas.DOFade(0f, 0.5f);
            merakCanvas.DOFade(0f, 0.5f);
            merpatiCanvas.DOFade(1f, 0.5f);

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
        if(hewanCanvas[0] == true) // kakatua
        {
            canvasMenu.DOFade(0f, 0.5f);
            kakatuaImage.gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(350f, 350f), 0.5f);
            kakatuaImage.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 0.5f);
            //kakatuaText.DOFade(0f, 0.5f);
            kakatuaBack.gameObject.SetActive(true);

            infoButtonUdara[0].gameObject.SetActive(false);
            bgUdara[0].gameObject.SetActive(true);

        }

        if (hewanCanvas[1] == true) // merak
        {
            canvasMenu.DOFade(0f, 0.5f);
            merakImage.gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(350f, 350f), 0.5f);
            merakImage.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 0.5f);
            //kakatuaText.DOFade(0f, 0.5f);
            merakBack.gameObject.SetActive(true);

            infoButtonUdara[1].gameObject.SetActive(false);
            bgUdara[1].gameObject.SetActive(true);
        }

        if (hewanCanvas[2] == true) // merpati
        {
            canvasMenu.DOFade(0f, 0.5f);
            merpatiImage.gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(350f, 350f), 0.5f);
            merpatiImage.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 0.5f);
            //kakatuaText.DOFade(0f, 0.5f);
            merpatiBack.gameObject.SetActive(true);

            infoButtonUdara[2].gameObject.SetActive(false);
            bgUdara[2].gameObject.SetActive(true);
        }

    }

    public void BackHewan()
    {
        if (hewanCanvas[0] == true) // kakatua
        {
            kakatuaCanvas.DOFade(0f, 0.5f);
            canvasMenu.DOFade(1f, 0.5f);

            kakatuaImage.gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(250f, 250f), 0.5f);
            kakatuaImage.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(200, -35), 0.5f);
            kakatuaBack.gameObject.SetActive(false);

            hewanCanvas[0] = false;

            infoButtonUdara[0].gameObject.SetActive(true);
            bgUdara[0].gameObject.SetActive(false);
        }

        if (hewanCanvas[1] == true) // merak
        {
            merakCanvas.DOFade(0f, 0.5f);
            canvasMenu.DOFade(1f, 0.5f);

            merakImage.gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(250f, 250f), 0.5f);
            merakImage.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(200, -35), 0.5f);
            merakBack.gameObject.SetActive(false);

            hewanCanvas[1] = false;

            infoButtonUdara[1].gameObject.SetActive(true);
            bgUdara[1].gameObject.SetActive(false);
        }

        if (hewanCanvas[2] == true) // merpati
        {
            merpatiCanvas.DOFade(0f, 0.5f);
            canvasMenu.DOFade(1f, 0.5f);

            merpatiImage.gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(250f, 250f), 0.5f);
            merpatiImage.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(200, -35), 0.5f);
            merpatiBack.gameObject.SetActive(false);

            hewanCanvas[2] = false;

            infoButtonUdara[2].gameObject.SetActive(true);
            bgUdara[2].gameObject.SetActive(false);
        }
    }

    public void Hewan0() // kakatua
    {
        hewanClick[0] = true;
        Debug.Log("hewan 0 click");
    }

    public void Hewan1() // merak
    {
        hewanClick[1] = true;
        Debug.Log("hewan 1 click");
    }

    public void Hewan2() // merpati
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
