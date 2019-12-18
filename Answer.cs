using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Answer 
{
    public enum Stats { Diplomacy, Literacy, Ethics, Intelligence, Charisma, Wisdom };

    public Stats statModified;

    public int statModValue;

    public string answerText;

    public void ModifyStat()
    {
        //PlayerManager.Instance.GetSheet().ModifyStat(statModified.ToString(), statModValue);
    }





}
