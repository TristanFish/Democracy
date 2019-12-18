using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterSheetStatDisplay : MonoBehaviour
{
    private static CharacterSheetStatDisplay _instance;


    public static CharacterSheetStatDisplay Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = (CharacterSheetStatDisplay)FindObjectOfType(typeof(CharacterSheetStatDisplay));
            }
            return _instance;
        }
    }

    private TextMeshProUGUI StatText;

    void Start()
    {
        StatText = GetComponent<TextMeshProUGUI>();
        UpdateStats();
    }

    public void UpdateStats()
    {
        StatText.text =  + PlayerManager.Instance.GetSheet().GetDip() + "\tDiplomacy\n" +
                         + PlayerManager.Instance.GetSheet().GetCharis() + "\tCharisma\n" +
                         + PlayerManager.Instance.GetSheet().GetEthic() + "\tEthics\n" +
                         + PlayerManager.Instance.GetSheet().GetIntel() + "\tIntelligence\n" +
                         + PlayerManager.Instance.GetSheet().GetLit() + "\tLiteracy\n" +
                         + PlayerManager.Instance.GetSheet().GetWis() + "\tWisdom\n";
    }


}
