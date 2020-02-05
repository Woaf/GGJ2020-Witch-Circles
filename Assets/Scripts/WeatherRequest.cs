using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Networking;

public class WeatherRequest : MonoBehaviour
{
    public int weather_type = 0;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        try
        {
            StartCoroutine(GetWeather());
        }
        catch { UnityEngine.Debug.Log(": Weather Request Exception, Defaulting Weather to 0 :"); }
    }

    IEnumerator GetWeather()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get("https://samples.openweathermap.org/data/2.5/weather?id=7284824&appid=8a6b7df49be7376c4d121e20473e2c89"))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            if (webRequest.isNetworkError)
            {
                UnityEngine.Debug.Log(": Weather Request Error: " + webRequest.error);
            }
            else
            {
                UnityEngine.Debug.Log(": Weather Received: " + webRequest.downloadHandler.text);

                var weather = JsonUtility.FromJson<RootObject>(webRequest.downloadHandler.text) as RootObject;
                var weatherId = weather.weather[0].id;
                if(
                    (200 <= weatherId && weatherId <= 231)
                    || (300 <= weatherId && weatherId <= 321)
                    || (500 <= weatherId && weatherId <= 531))
                {
                    this.weather_type = 2;
                }
                else if (801 <= weatherId && weatherId <= 804)
                {
                    this.weather_type = 1;
                }
                else
                {
                    this.weather_type = 0;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Weather api classes
    [System.Serializable]
    public class Coord
    {
        public double lon;
        public double lat;
    }
    [System.Serializable]
    public class Weather
    {
        public int id;
        public string main;
        public string description;
        public string icon;
    }
    [System.Serializable]
    public class Main
    {
        public double temp;
        public int pressure;
        public int humidity;
        public double temp_min;
        public double temp_max;
    }
    [System.Serializable]
    public class Wind
    {
        public double speed;
        public int deg;
    }
    [System.Serializable]
    public class Clouds
    {
        public int all;
    }
    [System.Serializable]
    public class Sys
    {
        public int type;
        public int id;
        public double message;
        public string country;
        public int sunrise;
        public int sunset;
    }

    [System.Serializable]
    public class RootObject
    {
        public Coord coord;
        public Weather[] weather;
        public Main main;
        public int visibility;
        public Wind wind;
        public Clouds clouds;
        public int dt;
        public Sys sys;
        public int id;
        public string name;
        public int cod;
    }

    #endregion
}
