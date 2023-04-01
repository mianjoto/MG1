using System;
using UnityEngine;

[System.Serializable]
public class TimeToProduce
{
    [field:SerializeReference] public float Hours { get; private set; }
    [field:SerializeReference] public float Minutes { get; private set; }
    [field:SerializeReference] public float Seconds { get; private set; }

    public (float, float, float) BaseTimeToProduce;

    public TimeToProduce(float hours, float minutes, float seconds)
    {
        BaseTimeToProduce = (hours, minutes, seconds);
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
    }

    public void SetTimeToProduce(float hours, float minutes, float seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
    }

    public uint ToSeconds()
    {
        return (uint)(Hours * 3600 + Minutes * 60 + Seconds);
    }

    #region Overrides
    public override bool Equals(object obj)
    {
        return this.Hours == ((TimeToProduce)obj).Hours
               && this.Minutes == ((TimeToProduce)obj).Minutes
               && this.Seconds == ((TimeToProduce)obj).Seconds;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Hours, Minutes, Seconds);
    }

    public override string ToString()
    {
        return "Time to Produce: " + Hours + " Hours, " + Minutes + " Minutes, " + Seconds + " Seconds";
    }
    #endregion
}