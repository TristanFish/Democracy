using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Dialogue 
{
    [SerializeField]
    public TextMeshProUGUI textDisplay;
    public static GameObject TextBackround;
    public GameObject continueButton;
    private string[] sentences;
    private int index = 0;
    public float typingSpeed;
    public bool HasPlayed;
    private float TimeBetween;
    private Minigame minigame;
    // Start is called before the first frame update


    public Dialogue(GameObject textBackground_, string[] sentences_, Minigame minigame_)
    {
        TextBackround = textBackground_;
        textDisplay = TextBackround.transform.Find("Dialogue").GetComponent<TextMeshProUGUI>();
        continueButton = TextBackround.transform.Find("Continue Button").gameObject;
        continueButton.GetComponent<Button>().onClick.AddListener(NextSentence);
        HasPlayed = false;
        sentences = sentences_;
        minigame = minigame_;
    }

     void Type()
    {
     textDisplay.text = sentences[index];  
    }

    public void PlayerEnter()
    {
        HasPlayed = true;
        TextBackround.SetActive(true);
        PlayerManager.Instance.SetMovement(false);
        continueButton.SetActive(true);
        Type();
        Debug.Log("I hit the player");
    }


    public void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            PlayerEnter();
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            TextBackround.SetActive(false);
            PlayerManager.Instance.SetMovement(true);
            index = 0;
            if(minigame != null)
            {
                minigame.StartMiniGame();
            }
        }
    }
}
