using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasController : MonoBehaviour {
    public Text Question;
    public Text QuestionInfo;
    public Text Answer1;
    public Text Answer2;
    public Text Answer3;
    public Text Answer4;
    public Text Information;
    public MapScriptCameraMovement CamMovement;
    int correctAnswer = 0;
    public GameObject questionCanvas;
    public GameObject informationCanvas;
    public GameObject goToMapButton;
    public GameObject seeInfoButton;
    public GameObject Correct;
    public GameObject Answer1GO;
    public GameObject Answer2GO;
    public GameObject Answer3GO;
    public GameObject Answer4GO;
    public GameObject Incorrect;
    public int DigSitesLeft = 19;
    public GameObject Reset;
    public GameObject FinishScreen;
    public ParticleSystem[] Particles;

    public static CanvasController instance;
    // Use this for initialization

    private void Start()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        FinishScreen.SetActive(false);
        questionCanvas.SetActive(false);
        informationCanvas.SetActive(false);
        CamMovement = FindObjectOfType<MapScriptCameraMovement>();
    }


    public void StartQuestion(CreateNewItem artifact)
    {
        Reset.SetActive(false);
        DigSitesLeft--;
        questionCanvas.SetActive(true);
        CamMovement.enabled = false;
        Question.text = artifact.question;
        //QuestionInfo.text = artifact.questionInfo;
        Answer1GO.SetActive(true);
        Answer2GO.SetActive(true);
        Answer3GO.SetActive(true);
        Answer4GO.SetActive(true);
        Answer1.text = artifact.answers[0];
        Answer2.text = artifact.answers[1];
        Answer3.text = artifact.answers[2];
        Answer4.text = artifact.answers[3];
        Information.text = artifact.itemInfo;
        correctAnswer = artifact.correctAnswer;
        goToMapButton.SetActive(false);
        seeInfoButton.SetActive(false);
        Correct.SetActive(false);
    }

    public void Button1()
    {
        CheckQuestion(1);
    }

    public void Button2()
    {
        CheckQuestion(2);
    }

    public void Button3()
    {
        CheckQuestion(3);
    }

    public void Button4()
    {
        CheckQuestion(4);
    }



    void CheckQuestion(int givenAnswer)
    {
        if (givenAnswer == correctAnswer)
        {
            goToMapButton.SetActive(true);
            seeInfoButton.SetActive(true);
            Correct.SetActive(true);
            Question.text = "";
            Answer1GO.SetActive(false);
            Answer2GO.SetActive(false);
            Answer3GO.SetActive(false);
            Answer4GO.SetActive(false);
            Incorrect.SetActive(false);
        }

        else {
            GoToInfo();
            Incorrect.SetActive(true);
            //say wrong
        }
    }

    public void GoToInfo()
    {
        questionCanvas.SetActive(false);
        informationCanvas.SetActive(true);
    }

    public void BackToMap()
    {
        questionCanvas.SetActive(false);
        informationCanvas.SetActive(false);
        if (DigSitesLeft == 0) {
            FinishScreen.SetActive(true);
        }
        else
        {
            CamMovement.enabled = true;
            Reset.SetActive(true);
        }
    }


    public void PlayParticleSystem(int array, Vector2 position) {
        Particles[array].transform.position = position;
        Particles[array].Play();
    }
}
