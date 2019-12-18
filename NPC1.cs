using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1 : MonoBehaviour
{
    public Dialogue dialogue;
    public string[] Sentences;
    private Minigame minigame;


    public enum MiniGameType {Crowd, MultipleChoice, SpeechBubbles};
    public MiniGameType NPCMiniGame;

    private void Start()
    {
        if (NPCMiniGame == MiniGameType.Crowd)
        {
            minigame = FindObjectOfType<CrowdMiniGame>();
        }

        if(NPCMiniGame == MiniGameType.MultipleChoice)
        {

            Debug.Log("Multi");
        }

        if(NPCMiniGame == MiniGameType.SpeechBubbles)
        {

            Debug.Log("Speech");
        }

        dialogue = new Dialogue(FindObjectOfType<Canvas>().transform.Find("TextBackground").gameObject, Sentences, minigame);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && dialogue.HasPlayed == false)
        {
            dialogue.PlayerEnter();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogue.HasPlayed = false;
    }
}
