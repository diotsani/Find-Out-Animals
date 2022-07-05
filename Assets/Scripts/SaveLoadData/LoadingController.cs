using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class LoadingController : MonoBehaviour
{
    public Image logoImg;

    public float timeFade = 3f;

    public void Awake()
    {

    }
    public void Start()
    {
        logoImg.DOFade(1, 1.5f);
        logoImg.GetComponent<RectTransform>().DOSizeDelta(new Vector2 (400, 320),1.5f);
    }

    void Update()
    {
        if(timeFade > 0.1f)
        {
            timeFade -= Time.deltaTime;
        }
        else
        {
            UserDataManager.Load();
            SceneManager.LoadScene(1);
        }
        
    }
}
