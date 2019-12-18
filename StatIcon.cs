using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class StatIcon
{
    public readonly string Name;
    private RawImage statImage;
    private TextMeshProUGUI statText;
    
    public StatIcon()
    {

    }

    public StatIcon(string _Name, GameObject _Image, GameObject _Text)
    {
        Name = _Name;
        statImage = _Image.GetComponent<RawImage>();
        statText = _Text.GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText(int newValue)
    {
        statText.text = newValue.ToString();
    }

}
