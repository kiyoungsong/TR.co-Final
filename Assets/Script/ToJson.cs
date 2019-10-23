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

    public void CreateJsonFile(string createPath, string fileName, string jsonData)
    {
        FileStream fileStream = new FileStream(string.Format($"{createPath}/{fileName}.json"), FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
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

    public void CreateJsonFile(string createPath, string fileName, string jsonData)
    {
        FileStream fileStream = new FileStream(string.Format($"{createPath}/{fileName}.json"), FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }
}





public class ToJson : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
