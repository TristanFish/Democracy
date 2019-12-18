using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class DisplayStats : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject StatInfo;

    // Start is called before the first frame update
    void Start()
    {
        StatInfo = transform.GetChild(0).gameObject;
    }



   public void OnPointerEnter(PointerEventData eventData)
    {
        StatInfo.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StatInfo.SetActive(false);
    }

    

}
