using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public static QuizManager instance;
    [SerializeField] private GameObject gameover;
    [SerializeField] private GameObject nextBtn;
    [SerializeField] private GameObject backBtn;
    [SerializeField] private GameObject backPanel;

    [Header("Game Manager")]
    public GameManager gameManagerDarat;
    public GameManager1 gameManagerAir;
    public GameManager2 gameManagerUdara;

    [Header("Question")]
    [SerializeField]
    private QuizDataScriptable questionData;
    [SerializeField]
    private Image questionImage;

    [Header("Question Array")]
    [SerializeField]
    private WordData[] answerWordArray;
    [SerializeField]
    private WordData[] questionWordArray;

    private char[] charArray = new char[8];
    private int currentAnswerIndex = 0;

    private bool correctAnswer = true;

    private List<int> selectedWordIndex;

    private int currentQuestionIndex = 0;

    private GameStatus gameStatus = GameStatus.Playing;

    private string answerWord;
    private int score = 0;

    private void Awake()
    {
        if (instance == null) instance = this;
        else
            Destroy(gameObject);

        selectedWordIndex = new List<int>();

        //jawabanBenarDarat0 = UserDataManager.Progress.jawabanBenarDarat[0];
    }

    private void Start()
    {
        SetQuestion();
    }

    private void SetQuestion()
    {
        currentAnswerIndex = 0;
        selectedWordIndex.Clear();
        questionImage.sprite = questionData.questions[currentQuestionIndex].questionImage;
        answerWord = questionData.questions[currentQuestionIndex].answer;

        ResetQuestion();

        for (int i = 0; i < answerWord.Length; i++)
        {
            charArray[i] = char.ToUpper(answerWord[i]);
        }

        for (int i = answerWord.Length; i < questionWordArray.Length; i++)
        {
            charArray[i] = (char)UnityEngine.Random.Range(65, 91);
        }

        charArray = ShuffleList.ShuffleListItems<char>(charArray.ToList()).ToArray();

        for (int i = 0; i < questionWordArray.Length; i++)
        {
            questionWordArray[i].SetChar(charArray[i]);
        }

        currentQuestionIndex++;

        gameStatus = GameStatus.Playing;
    }

    public void SelectedQuestion(WordData wordData)
    {
        if (gameStatus == GameStatus.Next || currentAnswerIndex >= answerWord.Length) return;

        selectedWordIndex.Add(wordData.transform.GetSiblingIndex());
        answerWordArray[currentAnswerIndex].SetChar(wordData.charValue);
        wordData.gameObject.SetActive(false);
        currentAnswerIndex++;

        if(currentAnswerIndex >= answerWord.Length)
        {
            correctAnswer = true;

            for (int i = 0; i < answerWord.Length; i++)
            {
                if (char.ToUpper(answerWord[i]) != char.ToUpper(answerWordArray[i].charValue))
                {
                    correctAnswer = false;
                    break;
                }
            }

            if (correctAnswer)
            {
                gameStatus = GameStatus.Next;
                score += 50;
                Debug.Log("Jawaban Anda Benar" + score);

                //jawabanBenarDarat0 = true; // jawaban benar no 1 panda
                //UserDataManager.Progress.jawabanBenarDarat[0] = true;

                if (currentQuestionIndex < questionData.questions.Count)
                {
                    Invoke("SetQuestion", 0.5f);
                }
                else
                {
                    backBtn.SetActive(false);

                    nextBtn.SetActive(true);
                    gameover.SetActive(true);
                    
                    //UserDataManager.Save();
                }
                
            }

            else if (!correctAnswer)
            {
                Debug.Log("Jawaban Anda Salah");
            }
        }
    }

    public void NextButton()
    {
        //Destroy(this.gameObject);
        //this.gameObject.SetActive(false);
        //SceneManager.LoadScene(2);
        //UserDataManager.Save();

    }

    public void NextPanda()
    {
        gameManagerDarat.pandaSelesai = true;
        //nextBtn.SetActive(false);
    }

    public void NextGajah()
    {
        gameManagerDarat.gajahSelesai = true;
        //nextBtn.SetActive(false);
    }

    public void NextRusa()
    {
        gameManagerDarat.rusaSelesai = true;
        //nextBtn.SetActive(false);
    }

    public void NextAir0()
    {
        gameManagerAir.airSelesai[0] = true;
        //nextBtn.SetActive(false);
    }

    public void NextAir1()
    {
        gameManagerAir.airSelesai[1] = true;
        //nextBtn.SetActive(false);
    }

    public void NextAir2()
    {
        gameManagerAir.airSelesai[2] = true;
        //nextBtn.SetActive(false);
    }

    public void NextUdara0()
    {
        gameManagerUdara.udaraSelesai[0] = true;
        //nextBtn.SetActive(false);
    }

    public void NextUdara1()
    {
        gameManagerUdara.udaraSelesai[1] = true;
        //nextBtn.SetActive(false);
    }

    public void NextUdara2()
    {
        gameManagerUdara.udaraSelesai[2] = true;
        //nextBtn.SetActive(false);
    }


    private void ResetQuestion()
    {
        for (int i = 0; i < answerWordArray.Length; i++)
        {
            answerWordArray[i].gameObject.SetActive(true);
            answerWordArray[i].SetChar('_');
        }

        for (int i = answerWord.Length; i < answerWordArray.Length; i++)
        {
            answerWordArray[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < questionWordArray.Length; i++)
        {
            questionWordArray[i].gameObject.SetActive(true);  
        }
    }

    public void ResetLastWord()
    {
        if(selectedWordIndex.Count > 0)
        {
            int index = selectedWordIndex[selectedWordIndex.Count - 1];
            questionWordArray[index].gameObject.SetActive(true);
            selectedWordIndex.RemoveAt(selectedWordIndex.Count - 1);
            currentAnswerIndex--;
            answerWordArray[currentAnswerIndex].SetChar('_');
        }

        
    }
}

[System.Serializable]

public class QuestionData
{
    public Sprite questionImage;
    public string answer;
}

public enum GameStatus
{
    Playing,
    Next
}

