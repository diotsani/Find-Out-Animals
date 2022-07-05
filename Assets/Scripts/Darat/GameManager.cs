using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject savebtn;
    public GameObject gameSelesai;
    public GameObject[] daratQuiz;

    public bool quizMuncul;

    public bool pandaSelesai;
    public bool gajahSelesai;
    public bool rusaSelesai;

    public bool jawabanBenarDarat0;
    public bool jawabanBenarDarat1;
    public bool jawabanBenarDarat2;

    public void Awake()
    {
        jawabanBenarDarat0 = UserDataManager.Progress.jawabanBenarDarat[0];
        jawabanBenarDarat1 = UserDataManager.Progress.jawabanBenarDarat[1];
        jawabanBenarDarat2 = UserDataManager.Progress.jawabanBenarDarat[2];
    }

    void Start()
    {
        quizMuncul = true;
    }

    void Update()
    {
        //QUIZ DARAT-------------------------------------------------------------------------------------
        if (daratQuiz[0]!= null) // Quiz Darat 1 Panda
        {
            if (quizMuncul == true)
            {
                daratQuiz[0].SetActive(true);
                quizMuncul = false;
            }

            if (quizMuncul == false) 
            {
                if (pandaSelesai == true) // Quiz 1 Sudah Selesai / sudah tidak aktif
                {
                    jawabanBenarDarat0 = true;
                    UserDataManager.Progress.jawabanBenarDarat[0] = true;
                    UserDataManager.Progress.lockArsipDarat[0] = false;
                    UserDataManager.Save();

                    Destroy(daratQuiz[0]);
                    //savebtn.active = true;
                }
            }
        }

        if (daratQuiz[0] == null) // Quiz Darat 2 Gajah
        {
            quizMuncul = true;

            if (daratQuiz[1] != null)
            {
                if (quizMuncul == true)
                {
                    daratQuiz[1].SetActive(true);
                    quizMuncul = false;
                }

                if (quizMuncul == false) 
                {
                    if (gajahSelesai == true) // Quiz 2 Sudah Selesai / sudah tidak aktif
                    {
                        jawabanBenarDarat1 = true;
                        UserDataManager.Progress.jawabanBenarDarat[1] = true;
                        UserDataManager.Progress.lockArsipDarat[1] = false;
                        UserDataManager.Save();

                        Destroy(daratQuiz[1]);
                        //savebtn.active = true;
                    }
                }
            }
        }

        if (daratQuiz[1] == null) // Quiz Darat 3 Rusa
        {
            quizMuncul = true;

            if (daratQuiz[2] != null)
            {
                if (quizMuncul == true)
                {
                    daratQuiz[2].SetActive(true);
                    quizMuncul = false;
                }

                if (quizMuncul == false) 
                {
                    if (rusaSelesai == true) // Quiz 3 Sudah Selesai / sudah tidak aktif
                    {
                        jawabanBenarDarat2 = true;
                        UserDataManager.Progress.jawabanBenarDarat[2] = true;
                        UserDataManager.Progress.lockArsipDarat[2] = false;
                        UserDataManager.Save();

                        Destroy(daratQuiz[2]);

                        gameSelesai.SetActive(true);
                        //savebtn.active = true;
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
