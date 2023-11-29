using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;
using Unity.Services.Core;
using System;

public class AnalyticsEvent : MonoBehaviour
{
    
    async void Start()
    {
        await UnityServices.InitializeAsync();
    }

    Dictionary<string, object> parameters = new Dictionary<string, object>()
    {
        { "String", "I need more bullets!" },
    { "Int", 2137 },
    { "Float", 0.451f },
    { "Bool", true },
    };

    public void OnStart()
    {
        string name = System.Environment.UserName;
        parameters.Add("Name:", name);
        AnalyticsService.Instance.CustomData("MyEvent", parameters);
        Debug.Log(name);
    }
}
