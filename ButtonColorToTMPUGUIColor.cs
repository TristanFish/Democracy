using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonColorToTMPUGUIColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private Button myButton;
    private TextMeshProUGUI TMPtext;
    // Start is called before the first frame update
    void Start()
    {
        myButton = GetComponent<Button>();
        TMPtext = GetComponent<TextMeshProUGUI>();
        myButton.onClick.AddListener(Clicked);
    }

    

    public void OnPointerEnter(PointerEventData eventData)
    {
        TMPtext.color = myButton.colors.highlightedColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TMPtext.color = myButton.colors.normalColor;
    }

    void Clicked()
    {
        TMPtext.color = myButton.colors.selectedColor;
    }
}
