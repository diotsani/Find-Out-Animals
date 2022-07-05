using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public GameObject savebtn;
    public GameObject gameSelesai;
    public GameObject[] airQuiz;

    public bool quizMuncul;

    public bool[] airSelesai = { false, false, false };

    public bool jawabanBenarAir0;
    public bool jawabanBenarAir1;
    public bool jawabanBenarAir2;

    public void Awake()
    {
        jawabanBenarAir0 = UserDataManager.Progress.jawabanBenarAir[0];
        jawabanBenarAir1 = UserDataManager.Progress.jawabanBenarAir[1];
        jawabanBenarAir2 = UserDataManager.Progress.jawabanBenarAir[2];
    }

    void Start()
    {
        quizMuncul = true;
    }

    void Update()
    {
        //QUIZ DARAT-------------------------------------------------------------------------------------
        if (airQuiz[0]!= null) // Quiz Darat 1 Panda
        {
            if (quizMuncul == true)
            {
                airQuiz[0].SetActive(true);
                quizMuncul = false;
            }

            if (quizMuncul == false) 
            {
                if (airSelesai[0] == true) // Quiz 1 Sudah Selesai / sudah tidak aktif
                {
                    jawabanBenarAir0 = true;
                    UserDataManager.Progress.jawabanBenarAir[0] = true;
                    UserDataManager.Progress.lockArsipAir[0] = false;
                    UserDataManager.Save();

                    Destroy(airQuiz[0]);
                    //savebtn.active = true;
                }
            }
        }

        if (airQuiz[0] == null) // Quiz Darat 2 Gajah
        {
            quizMuncul = true;

            if (airQuiz[1] != null)
            {
                if (quizMuncul == true)
                {
                    airQuiz[1].SetActive(true);
                    quizMuncul = false;
                }

                if (quizMuncul == false) 
                {
                    if (airSelesai[1] == true) // Quiz 2 Sudah Selesai / sudah tidak aktif
                    {
                        jawabanBenarAir1 = true;
                        UserDataManager.Progress.jawabanBenarAir[1] = true;
                        UserDataManager.Progress.lockArsipAir[1] = false;
                        UserDataManager.Save();

                        Destroy(airQuiz[1]);
                        //savebtn.active = true;
                    }
                }
            }
        }

        if (airQuiz[1] == null) // Quiz Darat 3 Rusa
        {
            quizMuncul = true;

            if (airQuiz[2] != null)
            {
                if (quizMuncul == true)
                {
                    airQuiz[2].SetActive(true);
                    quizMuncul = false;
                }

                if (quizMuncul == false) 
                {
                    if (airSelesai[2] == true) // Quiz 3 Sudah Selesai / sudah tidak aktif
                    {
                        jawabanBenarAir2 = true;
                        UserDataManager.Progress.jawabanBenarAir[2] = true;
                        UserDataManager.Progress.lockArsipAir[2] = false;
                        UserDataManager.Save();

                        Destroy(airQuiz[2]);
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
