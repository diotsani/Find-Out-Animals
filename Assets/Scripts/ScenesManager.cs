using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void LoadScene (string screenName)
    {
        SceneManager.LoadScene(screenName);
    }

    public void BackScene(string screenName)
    {
        SceneManager.LoadScene(screenName);
    }
}
