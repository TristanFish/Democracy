using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    private static Timer instance_;

    public static Timer Instance
    {
        get
        {
            return instance_;
        }
    }


    public TMP_Text DayText;
    public TMP_Text WeekText;
    public TMP_Text MonthText;

    public Scrollbar DaySlider;
    public Scrollbar WeekSlider;
    public Scrollbar MonthSlider;

    //This variable is the total amount of time that has passed in weeks
    public int TotalTimePassed = 1;

    public int CurrentDays = 0;
    public int CurrentWeeks = 0;
    public int CurrentMonths = 0;

    private int Days = 7;
    private int Weeks = 4;
    private int Months = 12;

    private void Awake()
    {
        instance_ = this;
    }

    void Start()
    {
        DaySlider.size = 0.0f;
        WeekSlider.size = 0.0f;
        MonthSlider.size = 0.0f;

        DayText.text = "0";
        WeekText.text = "0";
        MonthText.text = "0";

        CalculateCurrentTime();
    }

    public void HandleTimer()
    {
        TotalTimePassed += 1;
        CalculateCurrentTime();
    }

    public void StartTurn()
    {
        InvokeRepeating("HandleTimer", 1.0f, 1.0f);
    }
    public void EndTurn()
    {
        CancelInvoke("HandleTimer");
    }

    public void AddDays(int d)
    {
        TotalTimePassed += d;
        CalculateCurrentTime();
    }

    public void AddWeeks(int w)
    {
        TotalTimePassed += w * 7;
        CalculateCurrentTime();
    }

    public void AddMonths(int m)
    {
        TotalTimePassed += m * 28;
        CalculateCurrentTime();
    }

    private void CalculateCurrentTime()
    {
        //Calculate amount of monthss passed
        CurrentMonths = TotalTimePassed / 28;

        //Calculate amount of weeks passed
        CurrentWeeks = (TotalTimePassed / 7) % 4;

        //Calculate amount of days passed
        CurrentDays = TotalTimePassed % 7;

        //resize the sliders according to how long a week/month/year lasts
        DaySlider.size = CurrentDays / (float)Days;

        WeekSlider.size = CurrentWeeks / (float)Weeks;

        MonthSlider.size = CurrentMonths / (float)Months;
        
        

        DayText.text = "" + CurrentDays;
        WeekText.text = "" + CurrentWeeks;
        MonthText.text = "" + CurrentMonths;
    }
}

//Code for handle timer just in case we still want to do anything with it
/*if (CurrentWeeks >= 4)
{
    CurrentMonths += 1;
    MonthSlider.size += 1.0f / Months;
    CurrentWeeks = 0;
    WeekSlider.size = 0.0f;

}
if (CurrentMonths >= 12.0f)
{
    CurrentYears += 1;
    YearSlider.size += 1.0f / Years;
    CurrentMonths = 0;
    MonthSlider.size = 0.0f;
}

if (CurrentYears >= Years)
{
    //Finish Game
    Debug.Log("Game Has Finished");
}*/
