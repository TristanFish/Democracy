using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSheet 
{

    private int Intelligence;
    private int Wisdom;
    private int Diplomacy;
    private int Ethics;
    private int Charisma;
    private int Literacy;
    private int StatCap = 20;
    private PlayerManager PM;

    public CharacterSheet()
    {
        Intelligence = 0;
        Wisdom = 0;
        Diplomacy = 0;
        Ethics = 0;
        Charisma = 0;
        Literacy = 0;
    }

    public CharacterSheet(int Intel, int Wis, int Dip, int Ethic, int Charis, int Lit)
    {
        Intelligence = Intel;
        Wisdom = Wis;
        Diplomacy = Dip;
        Ethics = Ethic;
        Charisma = Charis;
        Literacy = Lit;
        PM = PlayerManager.Instance;
    }

    public void ResetStats()
    {
        Intelligence = 0;
        Wisdom = 0;
        Diplomacy = 0;
        Ethics = 0;
        Charisma = 0;
        Literacy = 0;
        PM.UpdateSheet();
    }

    #region ModifyStats
    public void ModifyIntel(int value)
    {
        Intelligence += value;
        if(Intelligence > StatCap)
        {
            Intelligence = StatCap;
        }

        if(Intelligence < 0)
        {
            Intelligence = 0;
        }
        PM.UpdateSheet();
        Debug.Log("Intelligence was modified by a value of " + value + " and is now equal to " + Intelligence);
    }

    public void ModifyWis(int value)
    {
        Wisdom += value;
        if (Wisdom > StatCap)
        {
            Wisdom = StatCap;
        }

        if (Wisdom < 0)
        {
            Wisdom = 0;
        }
        PM.UpdateSheet();
        Debug.Log("Wisdom was modified by a value of " + value + " and is now equal to " + Wisdom);
    }
    public void ModifyDip(int value)
    {
        Diplomacy += value;
        if (Diplomacy > StatCap)
        {
            Diplomacy = StatCap;
        }

        if (Diplomacy < 0)
        {
            Diplomacy = 0;
        }
        PM.UpdateSheet();
        Debug.Log("Diplomacy was modified by a value of " + value + " and is now equal to " + Diplomacy);
    }
    public void ModifyEthic(int value)
    {
        Ethics += value;
        if (Ethics > StatCap)
        {
            Ethics = StatCap;
        }

        if (Ethics < 0)
        {
            Ethics = 0;
        }
        PM.UpdateSheet();
        Debug.Log("Ethics was modified by a value of " + value + " and is now equal to " + Ethics);
    }
    public void ModifyCharis(int value)
    {
        Charisma += value;
        if (Charisma > StatCap)
        {
            Charisma = StatCap;
        }

        if (Charisma < 0)
        {
            Charisma = 0;
        }
        PM.UpdateSheet();
        Debug.Log("Charisma was modified by a value of " + value + " and is now equal to " + Charisma);
    }
    public void ModifyLit(int value)
    {
        Literacy += value;
        if (Literacy > StatCap)
        {
            Literacy = StatCap;
        }

        if (Literacy < 0)
        {
            Literacy = 0;
        }
        PM.UpdateSheet();
        Debug.Log("Literacy was modified by a value of " + value + " and is now equal to " + Literacy);
    }

    public void ModifyStat(string stat, int value)
    {
        if (stat == "Intelligence")
        {
            ModifyIntel(value);
            return;
        }
        if (stat == "Wisdom")
        {
            ModifyWis(value);
            return;
        }
        if (stat == "Diplomacy")
        {
            ModifyDip(value);
            return;
        }
        if (stat == "Ethics")
        {
            ModifyEthic(value);
            return;
        }
        if (stat == "Charisma")
        {
            ModifyCharis(value);
            return;
        }
        if (stat == "Literacy")
        {
            ModifyLit(value);
            return;
        }
        Debug.Log(stat + "Stat does not exist, Check your spelling");
        return;
    }

    #endregion

    #region GetStats

    public int GetIntel()
    {
        return Intelligence;
    }
    public int GetWis()
    {
        return Wisdom;
    }
    public int GetDip()
    {
        return Diplomacy;
    }
    public int GetEthic()
    {
        return Ethics;
    }
    public int GetCharis()
    {
        return Charisma;
    }
    public int GetLit()
    {
        return Literacy;
    }

    public int GetStat(string stat)
    {
        if(stat == "Intelligence")
        {
            return Intelligence;
        }
        if (stat == "Wisdom")
        {
            return Wisdom;
        }
        if (stat == "Diplomacy")
        {
            return Diplomacy;
        }
        if (stat == "Ethics")
        {
            return Ethics;
        }
        if (stat == "Charisma")
        {
            return Charisma;
        }
        if (stat == "Literacy")
        {
            return Literacy;
        }
        Debug.Log(stat + "Stat does not exist, Check your spelling");
        return -1;
    }

    #endregion
}
