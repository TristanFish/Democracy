using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventOutcome 
{
    public string Name;

    public enum Stats {Diplomacy, Literacy, Ethics, Intelligence, Charisma, Wisdom};

    [Tooltip("Choose what stats you want to check for the event.")]
    public Stats[] StatsThatAreChecked;

    [Tooltip("Pick a starting rate of success i.e. if the value is 100 the will always succeed.")]
    public int BaseSuccessChance;


    public Stats[] StatsRewarded;

    public int StatAmount;

    public int SuccessChance()
    {
        float ChanceTowin = 0;


        float StatsAverage = 0;

        foreach(Stats s in StatsThatAreChecked)
        {
            StatsAverage += PlayerManager.Instance.GetSheet().GetStat(s.ToString());
        }
        StatsAverage /= StatsThatAreChecked.Length;

        ChanceTowin = BaseSuccessChance + (100 - BaseSuccessChance) * 0.05f * StatsAverage;


        return Mathf.RoundToInt(ChanceTowin);
    }


    public void CalculateSuccess()
    {
        int result = Random.Range(0, 100);

        if(result >= Mathf.Abs(SuccessChance() - 100))
        {
            RewardStat(StatAmount);
            Debug.Log("Succeeded with a result of " + result);
        }
        else
        {
            RewardStat(-StatAmount);
            Debug.Log("Failed with a result of " + result);
        }
    }

    public string PrintOutcomeInfo()
    {
        string Info = " (";

        foreach(Stats s in StatsThatAreChecked)
        {
            Info += s.ToString();
            Info += ", ";
        }
        //Info.TrimEnd(', ');
        Info += ") " + SuccessChance() + "%";

        return Info;
    }

    public void RewardStat(int value)
    {
        foreach(Stats s in StatsRewarded)
        {
            PlayerManager.Instance.GetSheet().ModifyStat(s.ToString(), value);
        }
    }

}
