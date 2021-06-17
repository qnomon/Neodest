using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSystem : MonoBehaviour
{
    [SerializeField] Material daySkybox;
    [SerializeField] Material nightSkybox;
    [SerializeField] Light directionalLight;
    [SerializeField] Light directionalSecundary;
    [SerializeField] Color dayColor;
    [SerializeField] Color nightColor;
    [SerializeField] Color directionalNightColor;
    [SerializeField] Color directionalDayColor;

    public void SetNight(){
        RenderSettings.skybox = nightSkybox;
        RenderSettings.fogColor = nightColor;
        directionalLight.color = directionalNightColor;
    }

    public void SetDay(){
        RenderSettings.skybox = daySkybox;
        RenderSettings.fogColor = dayColor;
        directionalLight.color = directionalDayColor;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N)){
            SetNight();
        }
        if(Input.GetKeyDown(KeyCode.M)){
            SetDay();
        }
    }

}

