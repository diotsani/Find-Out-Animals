using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    public GameObject savebtn;
    public GameObject gameSelesai;
    public GameObject[] udaraQuiz;

    public bool quizMuncul;

    public bool[] udaraSelesai = { false, false, false };

    public bool jawabanBenarUdara0;
    public bool jawabanBenarUdara1;
    public bool jawabanBenarUdara2;

    public void Awake()
    {
        jawabanBenarUdara0 = UserDataManager.Progress.jawabanBenarUdara[0];
        jawabanBenarUdara1 = UserDataManager.Progress.jawabanBenarUdara[1];
        jawabanBenarUdara2 = UserDataManager.Progress.jawabanBenarUdara[2];
    }

    void Start()
    {
        quizMuncul = true;
    }

    void Update()
    {
        //QUIZ DARAT-------------------------------------------------------------------------------------
        if (udaraQuiz[0]!= null) // Quiz Darat 1 Panda
        {
            if (quizMuncul == true)
            {
                udaraQuiz[0].SetActive(true);
                quizMuncul = false;
            }

            if (quizMuncul == false) 
            {
                if (udaraSelesai[0] == true) // Quiz 1 Sudah Selesai / sudah tidak aktif
                {
                    jawabanBenarUdara0 = true;
                    UserDataManager.Progress.jawabanBenarUdara[0] = true;
                    UserDataManager.Progress.lockArsipUdara[0] = false;
                    UserDataManager.Save();

                    Destroy(udaraQuiz[0]);
                    //savebtn.active = true;
                }
            }
        }

        if (udaraQuiz[0] == null) // Quiz Darat 2 Gajah
        {
            quizMuncul = true;

            if (udaraQuiz[1] != null)
            {
                if (quizMuncul == true)
                {
                    udaraQuiz[1].SetActive(true);
                    quizMuncul = false;
                }

                if (quizMuncul == false) 
                {
                    if (udaraSelesai[1] == true) // Quiz 2 Sudah Selesai / sudah tidak aktif
                    {
                        jawabanBenarUdara1 = true;
                        UserDataManager.Progress.jawabanBenarUdara[1] = true;
                        UserDataManager.Progress.lockArsipUdara[1] = false;
                        UserDataManager.Save();

                        Destroy(udaraQuiz[1]);
                        //savebtn.active = true;
                    }
                }
            }
        }

        if (udaraQuiz[1] == null) // Quiz Darat 3 Rusa
        {
            quizMuncul = true;

            if (udaraQuiz[2] != null)
            {
                if (quizMuncul == true)
                {
                    udaraQuiz[2].SetActive(true);
                    quizMuncul = false;
                }

                if (quizMuncul == false) 
                {
                    if (udaraSelesai[2] == true) // Quiz 3 Sudah Selesai / sudah tidak aktif
                    {
                        jawabanBenarUdara2 = true;
                        UserDataManager.Progress.jawabanBenarUdara[2] = true;
                        UserDataManager.Progress.lockArsipUdara[2] = false;
                        UserDataManager.Save();

                        Destroy(udaraQuiz[2]);
                        //savebtn.active = true;

                        gameSelesai.SetActive(true);
                    }
                }
            }
        }
        //------------------------------------------------------------------------------------------
    }


    public void SaveJawaban()
    {
        UserDataManager.Save();
        savebtn.SetActive(false);
        //SceneManager.LoadScene(2);
    }
}
