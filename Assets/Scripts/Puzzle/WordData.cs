using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WordData : MonoBehaviour
{
    

    [SerializeField]
    private Text charText;

    [HideInInspector]
    public char charValue;

    private Button buttonObj;

    private void Awake()
    {
        buttonObj = GetComponent<Button>();
         if(buttonObj)
        {
            buttonObj.onClick.AddListener(() => CharSelected());
        }
    }


    void Update()
    {
        
    }

    public void SetChar(char value)
    {
        charText.text = value + "";
        charValue = value;
    }

    private void CharSelected()
    {
        QuizManager.instance.SelectedQuestion(this);
    }
}
