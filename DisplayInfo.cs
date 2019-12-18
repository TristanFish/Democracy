using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DisplayInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject InfoText;
    private Button ThisButton;

   private void Start()
    {
        InfoText.GetComponent<TextMeshProUGUI>().text = gameObject.name;
        ThisButton = GetComponent<Button>();
        InfoText.SetActive(false);
        ThisButton.onClick.AddListener(TravelTo);
    }
    // Update is called once per frame

    public void DrawText()
    {
        InfoText.SetActive(true);
    }

    public void RemoveText()
    {
        InfoText.SetActive(false);
    }

    private void TravelTo()
    {
        TheSceneManager.Instance.TravelToBuilding(gameObject.name);
    }

    private void OnDisable()
    {
        InfoText.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        DrawText();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        RemoveText();
    }
}
