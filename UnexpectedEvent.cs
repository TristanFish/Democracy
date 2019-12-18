using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class UnexpectedEvent 
{
    public string Name;

    
    public static GameObject EventBox;
    private static GameObject ButtonTemplate;

    [Tooltip("Text that gives a description of what's happening in the event.")]
    public string EventText;
    [Tooltip("Image that displays for the event.")]
    public Sprite EventImage;

    [Tooltip("Text that will appear for the buttons, more elements in this array means more buttons (Dont do more than 4).")]
    public string[] ButtonText;

    private Button[] EventChoices;

    [Tooltip("Array that holds the outcome for event choices (This array should be the same size as the ButtonText array).")]
    public EventOutcome[] OutcomeOf;

    private GameObject EventBox_;

    //Don't use this constructor, Change the values in Editor
    public UnexpectedEvent(GameObject EventBoxPrefab)
    {
        EventBox = EventBoxPrefab;

        EventBox.GetComponentInChildren<Image>().sprite = EventImage;

        EventChoices = new Button[ButtonText.Length];

        GameObject ButtonHolder = EventBox.transform.Find("ButtonHolder").gameObject;

        ButtonTemplate = EventBox.transform.Find("Button").gameObject;

        for (int i = 0; i < ButtonHolder.transform.childCount; i++)
        {
            Object.Destroy(ButtonHolder.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < EventChoices.Length; i++)
        {
            Object.Instantiate(ButtonTemplate, ButtonHolder.transform);
        }

        for (int i = 0; i < ButtonText.Length; i++)
        {
            EventChoices[i].GetComponent<TextMeshProUGUI>().text = ButtonText[i];
        }
    }

    //Sets the image, buttons, text and StatChecks for the event
    public void ConstructEvent(Transform EventParent)
    {
        PlayerManager.Instance.SetMovement(false);

        EventBox_ = Object.Instantiate(EventBox, EventParent);

        EventBox_.transform.Find("EventPicture").GetComponentInChildren<Image>().sprite = EventImage;
        EventBox_.transform.Find("EventPicture").GetComponentInChildren<Image>().type = Image.Type.Sliced;

        GameObject ButtonHolder = EventBox_.transform.Find("ButtonHolder").gameObject;

        ButtonTemplate = ButtonHolder.transform.Find("Button").gameObject;

        EventBox_.transform.Find("EventDialogue").GetComponent<TextMeshProUGUI>().text = EventText;


        for(int i = 0; i < ButtonHolder.transform.childCount; i++)
        {
            Object.Destroy(ButtonHolder.transform.GetChild(i).gameObject);
        }

        for(int i = 0; i < ButtonText.Length; i++)
        {
            GameObject NewButton = Object.Instantiate(ButtonTemplate, ButtonHolder.transform);
            NewButton.GetComponent<Button>().enabled = true;
            NewButton.GetComponent<Button>().onClick.AddListener(OutcomeOf[i].CalculateSuccess);
            NewButton.GetComponent<Button>().onClick.AddListener(DeconstructEvent);
            NewButton.GetComponent<TextMeshProUGUI>().enabled = true;
            NewButton.GetComponent<TextMeshProUGUI>().text = ButtonText[i] + OutcomeOf[i].PrintOutcomeInfo();
            NewButton.GetComponent<ButtonColorToTMPUGUIColor>().enabled = true;
            OutcomeOf[i].Name = ButtonText[i];
        }
    }

    public void DeconstructEvent()
    {
        PlayerManager.Instance.SetMovement(true);

        Object.Destroy(EventBox_);
    }

    public void HideEvent()
    {

    }

}
