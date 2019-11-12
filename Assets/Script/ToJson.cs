using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class ResultLungToJson
{
    public string candle_count;
    public string Lung_Date;

    public string SaveToString(object obj)
    {
        return JsonUtility.ToJson(obj);
    }
}

public class ResultBreathingToJson
{
    public string exhaleScore;
    public string exhale_Date;
    public string inhaleScore;
    public string inhale_Date;

    public string SaveToString(object obj)
    {
        return JsonUtility.ToJson(obj);
    }
}

public class ToJson : MonoBehaviour{}
