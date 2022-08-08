using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ArsipManager : MonoBehaviour
{
    [Header("ArsipJenis")]
    public ArsipDarat arsipDarat;
    public ArsipAir arsipAir;
    public ArsipUdara arsipUdara;

    [Header("Array")]
    public Button[] jenisHewanButton;
    public CanvasGroup[] jenisHewanCanvas;

    public GameObject buttonHolder;
    public GameObject arsipHolder;

    void Start()
    {
        jenisHewanButton[0].onClick.AddListener(JenisDarat);
        jenisHewanButton[1].onClick.AddListener(JenisAir);
        jenisHewanButton[2].onClick.AddListener(JenisUdara);
    }


    void Update()
    {
        
    }

    public void JenisDarat()
    {
        arsipDarat.gameObject.SetActive(true);
        arsipAir.gameObject.SetActive(false);
        arsipUdara.gameObject.SetActive(false);

        jenisHewanCanvas[0].DOFade(1f, 0.5f); // DARAT
        jenisHewanCanvas[1].DOFade(0f, 0.5f);
        jenisHewanCanvas[2].DOFade(0f, 0.5f);

        jenisHewanCanvas[0].gameObject.SetActive(true);
        jenisHewanCanvas[1].gameObject.SetActive(false);
        jenisHewanCanvas[2].gameObject.SetActive(false);

        arsipAir.lumbaCanvas.DOFade(0f, 0.5f);
        arsipAir.koiCanvas.DOFade(0f, 0.5f);
        arsipAir.pausCanvas.DOFade(0f, 0.5f);

        arsipUdara.kakatuaCanvas.DOFade(0f, 0.5f);
        arsipUdara.merakCanvas.DOFade(0f, 0.5f);
        arsipUdara.merpatiCanvas.DOFade(0f, 0.5f);

        Holder();
        Debug.Log("Menu Darat Clicked");
    }

    public void JenisAir()
    {
        arsipDarat.gameObject.SetActive(false);
        arsipAir.gameObject.SetActive(true);
        arsipUdara.gameObject.SetActive(false);

        jenisHewanCanvas[0].DOFade(0f, 0.5f);
        jenisHewanCanvas[1].DOFade(1f, 0.5f); // AIR
        jenisHewanCanvas[2].DOFade(0f, 0.5f);

        jenisHewanCanvas[0].gameObject.SetActive(false);
        jenisHewanCanvas[1].gameObject.SetActive(true);
        jenisHewanCanvas[2].gameObject.SetActive(false);

        arsipDarat.pandaCanvas.DOFade(0f, 0.5f);
        arsipDarat.gajahCanvas.DOFade(0f, 0.5f);
        arsipDarat.rusaCanvas.DOFade(0f, 0.5f);

        arsipUdara.kakatuaCanvas.DOFade(0f, 0.5f);
        arsipUdara.merakCanvas.DOFade(0f, 0.5f);
        arsipUdara.merpatiCanvas.DOFade(0f, 0.5f);

        Holder();
        Debug.Log("Menu Air Clicked");
    }

    public void JenisUdara()
    {
        arsipDarat.gameObject.SetActive(false);
        arsipAir.gameObject.SetActive(false);
        arsipUdara.gameObject.SetActive(true);

        jenisHewanCanvas[0].DOFade(0f, 0.5f);
        jenisHewanCanvas[1].DOFade(0f, 0.5f);
        jenisHewanCanvas[2].DOFade(1f, 0.5f); // UDARA

        jenisHewanCanvas[0].gameObject.SetActive(false);
        jenisHewanCanvas[1].gameObject.SetActive(false);
        jenisHewanCanvas[2].gameObject.SetActive(true);

        arsipDarat.pandaCanvas.DOFade(0f, 0.5f);
        arsipDarat.gajahCanvas.DOFade(0f, 0.5f);
        arsipDarat.rusaCanvas.DOFade(0f, 0.5f);

        arsipAir.lumbaCanvas.DOFade(0f, 0.5f);
        arsipAir.koiCanvas.DOFade(0f, 0.5f);
        arsipAir.pausCanvas.DOFade(0f, 0.5f);

        Holder();
        Debug.Log("Menu Udara Clicked");
    }

    private void Holder()
    {
        buttonHolder.SetActive(false);
        arsipHolder.SetActive(true);
    }
}
