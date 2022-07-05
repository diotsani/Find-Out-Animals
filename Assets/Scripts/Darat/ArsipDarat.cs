using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class ArsipDarat : MonoBehaviour
{
    public GameObject panelLockNotif;
    public CanvasGroup canvasMenu;
    
    public Button[] hewanButton;

    public bool[] hewanClick = { false, false, false};
    public bool[] hewanCanvas = { false, false, false };

    [Header("Kunci Arsip Darat")]
    public GameObject[] lockDarat;
    public bool lockArsipDarat0;
    public bool lockArsipDarat1;
    public bool lockArsipDarat2;

    [Header("Info Button & BG Darat")]
    public Button[] infoButtonDarat;
    public Image[] bgDarat;

    [Header("Panda")]
    public CanvasGroup pandaCanvas;
    public Image pandaImage;
    public Button pandaBack;
    public Text pandaText;

    [Header("Gajah")]
    public CanvasGroup gajahCanvas;
    public Image gajahImage;
    public Button gajahBack;
    public Text gajahText;

    [Header("Rusa")]
    public CanvasGroup rusaCanvas;
    public Image rusaImage;
    public Button rusaBack;
    public Text rusaText;

    public void Awake()
    {
        lockArsipDarat0 = UserDataManager.Progress.lockArsipDarat[0];
        lockArsipDarat1 = UserDataManager.Progress.lockArsipDarat[1];
        lockArsipDarat2 = UserDataManager.Progress.lockArsipDarat[2];

        if (lockArsipDarat0 == false)
        {
            lockDarat[0].SetActive(false);
        }

        if (lockArsipDarat1 == false)
        {
            lockDarat[1].SetActive(false);
        }

        if (lockArsipDarat2 == false)
        {
            lockDarat[2].SetActive(false);
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
        if (hewanClick[0] == true) // Panda
        {

            pandaCanvas.gameObject.SetActive(true);
            gajahCanvas.gameObject.SetActive(false);
            rusaCanvas.gameObject.SetActive(false);

            pandaCanvas.DOFade(1f, 0.5f);
            gajahCanvas.DOFade(0f, 0.5f);
            rusaCanvas.DOFade(0f, 0.5f);

            hewanCanvas[0] = true;
            hewanCanvas[1] = false;
            hewanCanvas[2] = false;

            hewanClick[0] = false;

            
        }

        if (hewanClick[1] == true) // Gajah
        {
            pandaCanvas.gameObject.SetActive(false);
            gajahCanvas.gameObject.SetActive(true);
            rusaCanvas.gameObject.SetActive(false);

            pandaCanvas.DOFade(0f, 0.5f);
            gajahCanvas.DOFade(1f, 0.5f);
            rusaCanvas.DOFade(0f, 0.5f);

            hewanCanvas[0] = false;
            hewanCanvas[1] = true;
            hewanCanvas[2] = false;

            hewanClick[1] = false;
        }

        if (hewanClick[2] == true) // Rusa
        {
            pandaCanvas.gameObject.SetActive(false);
            gajahCanvas.gameObject.SetActive(false);
            rusaCanvas.gameObject.SetActive(true);

            pandaCanvas.DOFade(0f, 0.5f);
            gajahCanvas.DOFade(0f, 0.5f);
            rusaCanvas.DOFade(1f, 0.5f);

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
        if(hewanCanvas[0] == true) // Panda
        {
            canvasMenu.DOFade(0f, 0.5f);
            pandaImage.gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(350f, 350f), 0.5f);
            pandaImage.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 0.5f);
            //pandaText.DOFade(0f, 0.5f);
            pandaBack.gameObject.SetActive(true);

            infoButtonDarat[0].gameObject.SetActive(false);
            bgDarat[0].gameObject.SetActive(true);

            Debug.Log("Info Panda Clicked");
        }

        if (hewanCanvas[1] == true) // Gajah
        {
            canvasMenu.DOFade(0f, 0.5f);
            gajahImage.gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(350f, 350f), 0.5f);
            gajahImage.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 0.5f);
            //pandaText.DOFade(0f, 0.5f);
            gajahBack.gameObject.SetActive(true);

            infoButtonDarat[1].gameObject.SetActive(false);
            bgDarat[1].gameObject.SetActive(true);

            Debug.Log("Info Gajah Clicked");
        }

        if (hewanCanvas[2] == true) // Rusa
        {
            canvasMenu.DOFade(0f, 0.5f);
            rusaImage.gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(350f, 350f), 0.5f);
            rusaImage.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 0.5f);
            //pandaText.DOFade(0f, 0.5f);
            rusaBack.gameObject.SetActive(true);

            infoButtonDarat[2].gameObject.SetActive(false);
            bgDarat[2].gameObject.SetActive(true);

            Debug.Log("Info Rusa Clicked");
        }

    }

    public void BackHewan()
    {
        if (hewanCanvas[0] == true) // Panda
        {
            pandaCanvas.DOFade(0f, 0.5f);
            canvasMenu.DOFade(1f, 0.5f);

            pandaImage.gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(250f, 250f), 0.5f);
            pandaImage.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(200, -35), 0.5f);
            pandaBack.gameObject.SetActive(false);

            hewanCanvas[0] = false;

            infoButtonDarat[0].gameObject.SetActive(true);
            bgDarat[0].gameObject.SetActive(false);
        }

        if (hewanCanvas[1] == true) // Gajah
        {
            gajahCanvas.DOFade(0f, 0.5f);
            canvasMenu.DOFade(1f, 0.5f);

            gajahImage.gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(250f, 250f), 0.5f);
            gajahImage.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(200, -35), 0.5f);
            gajahBack.gameObject.SetActive(false);

            hewanCanvas[1] = false;

            infoButtonDarat[1].gameObject.SetActive(true);
            bgDarat[1].gameObject.SetActive(false);
        }

        if (hewanCanvas[2] == true) // Rusa
        {
            rusaCanvas.DOFade(0f, 0.5f);
            canvasMenu.DOFade(1f, 0.5f);

            rusaImage.gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(250f, 250f), 0.5f);
            rusaImage.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(200, -35), 0.5f);
            rusaBack.gameObject.SetActive(false);

            hewanCanvas[2] = false;

            infoButtonDarat[2].gameObject.SetActive(true);
            bgDarat[2].gameObject.SetActive(false);
        }
    }

    public void Hewan0() // Panda
    {
        hewanClick[0] = true;
        Debug.Log("hewan 0 click");
    }

    public void Hewan1() // Gajah
    {
        hewanClick[1] = true;
        Debug.Log("hewan 1 click");
    }

    public void Hewan2() // Rusa
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
