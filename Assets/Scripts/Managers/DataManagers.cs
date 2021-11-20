using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManagers : MonoBehaviour
{
    string _defaultPath = "Data/";
    public void Init()
    {

    }
    public T PopulateObject<T>(JObject jo, T obj)
    {
        JsonConvert.PopulateObject(jo.ToString(), obj);
        return obj;
    }
    public T PopulateObject<T>(string str, T obj)
    {
        if (str.Contains("/"))
        {
            JsonConvert.PopulateObject(GetJson(str), obj);
            return obj;
        }
        JsonConvert.PopulateObject(str, obj);
        return obj;

    }
    public JObject GetJObject(string path)
    {
        return JObject.Parse(GetJson(path));
    }
    public string GetJson(string path)
    {
        TextAsset ta = Managers.ResourceMgr.Load<TextAsset>($"{_defaultPath}{path}");
        if (ta is null) return File.ReadAllText(path);
        return ta.text;
    }
    public void Clear()
    {

    }
}
