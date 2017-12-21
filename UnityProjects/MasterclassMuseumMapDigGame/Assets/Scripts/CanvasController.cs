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
        questionCanvas.SetActive(false);
        informationCanvas.SetActive(false);
        CamMovement = FindObjectOfType<MapScriptCameraMovement>();
    }


    public void StartQuestion(CreateNewItem artifact)
    {
        questionCanvas.SetActive(true);
        CamMovement.enabled = false;
        Question.text = artifact.question;
        QuestionInfo.text = artifact.questionInfo;
        Answer1.text = artifact.answers[0];
        Answer2.text = artifact.answers[1];
        Answer3.text = artifact.answers[2];
        Answer4.text = artifact.answers[3];
        Information.text = artifact.itemInfo;
        correctAnswer = artifact.correctAnswer;
        goToMapButton.SetActive(false);
        seeInfoButton.SetActive(false);
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
        }

        else {
            GoToInfo();
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
        CamMovement.enabled = true;
    }
}
