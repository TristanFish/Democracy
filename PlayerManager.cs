using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    private static PlayerManager _instance;

    private CharacterSheet PlayerSheet;
    public StatIcon[] Icons;
    public GameObject StatBar;

    public static PlayerManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = (PlayerManager)FindObjectOfType(typeof(PlayerManager));
                if(_instance == null)
                {
                    Debug.Log("No PlayerManager script exists");
                }
            }
            return _instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        PlayerSheet = new CharacterSheet(PlayerPrefs.GetInt("Intelligence"),
                                         PlayerPrefs.GetInt("Wisdom"),
                                         PlayerPrefs.GetInt("Diplomacy"),
                                         PlayerPrefs.GetInt("Ethics"),
                                         PlayerPrefs.GetInt("Charisma"),
                                         PlayerPrefs.GetInt("Literacy"));

        Icons = new StatIcon[StatBar.transform.childCount];

        for(int i = 0; i < StatBar.transform.childCount; i++)
        {
            Icons[i] = new StatIcon(StatBar.transform.GetChild(i).name, StatBar.transform.GetChild(i).gameObject, StatBar.transform.GetChild(i).GetChild(0).GetChild(0).GetChild(0).gameObject);
        }
        Save();
        UpdateSheet();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) { PlayerSheet.ResetStats();     }
        

        if (Input.GetKeyDown(KeyCode.Keypad1)) { PlayerSheet.ModifyDip(5);   }
        if (Input.GetKeyDown(KeyCode.Keypad2)) { PlayerSheet.ModifyCharis(5);}
        if (Input.GetKeyDown(KeyCode.Keypad3)) { PlayerSheet.ModifyEthic(5); }
        if (Input.GetKeyDown(KeyCode.Keypad4)) { PlayerSheet.ModifyIntel(5); }
        if (Input.GetKeyDown(KeyCode.Keypad5)) { PlayerSheet.ModifyLit(5);   }
        if (Input.GetKeyDown(KeyCode.Keypad6)) { PlayerSheet.ModifyWis(5);   }

        if(Input.GetKeyDown(KeyCode.A)) { EventManager.Instance.StartRandomEvent(); }

        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) { Timer.Instance.AddDays(3); }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad7)) { Timer.Instance.AddWeeks(3);}
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad7)) { Timer.Instance.AddMonths(1); }

        if(Input.GetKeyDown(KeyCode.LeftControl)) { Application.Quit(); }
    }


    public void Save()
    {   
        PlayerPrefs.SetInt("Intelligence", PlayerSheet.GetIntel()); 
        PlayerPrefs.SetInt("Wisdom",         PlayerSheet.GetWis());
        PlayerPrefs.SetInt("Diplomacy",      PlayerSheet.GetDip());
        PlayerPrefs.SetInt("Ethics",       PlayerSheet.GetEthic());
        PlayerPrefs.SetInt("Charisma",    PlayerSheet.GetCharis());
        PlayerPrefs.SetInt("Literacy",       PlayerSheet.GetLit());
       
    }

    public void UpdateSheet()
    {
        foreach(StatIcon s in Icons)
        {
            s.UpdateText(PlayerSheet.GetStat(s.Name));
        }

        //CharacterSheetStatDisplay.Instance.UpdateStats();
    }

    public void SetMovement(bool state)
    {
        GetComponent<ClickToMove_V2>().enabled = state;
    }

    public CharacterSheet GetSheet()
    {
        return PlayerSheet;
    }

    private void OnApplicationQuit()
    {
        Save();
    }

}
