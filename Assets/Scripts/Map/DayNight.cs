using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    [Range(0,1)]
    public float TimeOfDay;
    public float DayDuration = 30f;

    public Light Sun;
    public Light Moon;
    
    public AnimationCurve SunCurve;
    public AnimationCurve MoonCurve;
    public AnimationCurve SkyBoxCurve;
    
    private float sunIntensity;
    private float MoonIntensity;

    public Material DaySkyBox;
    public Material NightSkyBox;
    // Start is called before the first frame update
    void Start()
    {
        sunIntensity = Sun.intensity;
        MoonIntensity = Moon.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        TimeOfDay += Time.deltaTime / DayDuration;
        if (TimeOfDay > 1)
        {
            TimeOfDay -= 1;
        }
        
        RenderSettings.skybox.Lerp(DaySkyBox,NightSkyBox,SkyBoxCurve.Evaluate(TimeOfDay));
        RenderSettings.sun = SkyBoxCurve.Evaluate(TimeOfDay) > 0.1 ? Sun : Moon;
        DynamicGI.UpdateEnvironment();
        
        Sun.transform.localRotation = Quaternion.Euler(TimeOfDay * 360f,180,0);
        Moon.transform.localRotation = Quaternion.Euler(TimeOfDay * 360f + 180f,180,0);
        
        Sun.intensity = sunIntensity * SunCurve.Evaluate(TimeOfDay);
        Moon.intensity = MoonIntensity * MoonCurve.Evaluate(TimeOfDay);
    }
}
