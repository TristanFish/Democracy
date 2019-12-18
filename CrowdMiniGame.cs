using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrowdMiniGame : Minigame
{


    public GameObject MultipleChoice;
    public GameObject QuestionPopup;
    [Tooltip("Put The Crowd Levels Below.")]
    public GameObject[] CrowdLevels;
    public GameObject QuestionAskers;
    [Tooltip("Put The MiniGame GUI Below")]
    public GameObject Background;
    public Timer timer;

    [Tooltip("Input All the questions here")]
    public Question[] Questions;

    public TMP_Text QuestionBox1;
    public TMP_Text QuestionBox2;

    public int QuestionsAnswered = 0;
    private bool[] wasAnswered;


    // Start is called before the first frame update
    void Start()
    {
        foreach(Question q in Questions)
        {
            q.miniGame = this;
            q.MultiChoice = MultipleChoice;
            q.questionBox = QuestionPopup;
        }

        wasAnswered = new bool[Questions.Length];

        QuestionPopup.SetActive(false);
        CrowdLevels[0].SetActive(false);
        CrowdLevels[1].SetActive(false);
        QuestionAskers.SetActive(false);
        Background.SetActive(false);
        
    }

    public void ButtonClicked(GameObject currentButton)
    {
        currentButton.SetActive(false);
        QuestionAskers.SetActive(false);
        QuestionPopup.SetActive(true);
        MultipleChoice.SetActive(true);

        int questionToAnswer;

        do
        {
            questionToAnswer = Random.Range(0, Questions.Length);

        } while (wasAnswered[questionToAnswer] == true);

        wasAnswered[questionToAnswer] = true;
        Questions[questionToAnswer].ConstructQuestion();

    }

    public void OnQuestionAnswered()
    {
        QuestionAskers.SetActive(true);
        QuestionPopup.SetActive(false);
        MultipleChoice.SetActive(false);
        QuestionsAnswered++;
        if (QuestionsAnswered >= 3)
        {
            EndMiniGame();
        }
    }

    public override void StartMiniGame()
    {
        Background.SetActive(true);
        CrowdLevels[0].SetActive(true);

        QuestionAskers.SetActive(true);
        for(int i = 0; i < QuestionAskers.transform.childCount; i++)
        {
            QuestionAskers.transform.GetChild(i).gameObject.SetActive(true);
        }

        PlayerManager.Instance.SetMovement(false);
        timer.EndTurn();
    }

    public override void EndMiniGame()
    {
        for(int i = 0; i < wasAnswered.Length; i++)
        {
            wasAnswered[i] = false;
        }

        Background.SetActive(false);
        QuestionAskers.SetActive(false);
        QuestionPopup.SetActive(false);
        CrowdLevels[0].SetActive(false);
        PlayerManager.Instance.SetMovement(true);
        Timer.Instance.AddWeeks(1);
        QuestionsAnswered = 0;
        Debug.Log("Destruct Minigame");  
    }
}
