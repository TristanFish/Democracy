using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[System.Serializable]
public class Question
{
    public GameObject MultiChoice;

    public GameObject questionBox;

    public string questionText;

    public Answer[] answers;

    private Button[] answerButtons;

    [System.NonSerialized]
    public CrowdMiniGame miniGame;

    public void ConstructQuestion()
    {
        questionBox.SetActive(true);

        questionBox.transform.Find("Question Text").GetComponent<TextMeshProUGUI>().text = questionText;



        Transform ButtonFolder = questionBox.transform.Find("ButtonFolder");

        GameObject button = ButtonFolder.GetChild(0).gameObject;

        for(int i = 0; i < ButtonFolder.childCount; i++)
        {
            Object.Destroy(ButtonFolder.GetChild(i).gameObject);
        }

        //Set up the buttons' interaction, an text
        foreach(Answer a in answers)
        {
            GameObject newButton = Object.Instantiate(button, ButtonFolder);

            newButton.SetActive(true);
            newButton.GetComponent<Image>().enabled = true;
            newButton.transform.GetChild(0).GetComponent<Image>().enabled = true;
            newButton.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(a.ModifyStat);
            newButton.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(miniGame.OnQuestionAnswered);
            newButton.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(DestructQuestion);
            newButton.transform.GetChild(0).GetComponent<Button>().enabled = true;
            newButton.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = a.answerText;
            newButton.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        }

    }

    public void DestructQuestion()
    {
        MultiChoice.SetActive(false);
    }


}
   
