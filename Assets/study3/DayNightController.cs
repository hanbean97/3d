using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour
{
    private Light lightDirctional;
    [SerializeField, Range(0f, 24f)] float time;

    public static DayNightController instance;
    [SerializeField] bool auto;//«œ¥√¿Ãπ„¿Œ¡ˆæ∆¥—¡ˆ
    [SerializeField] bool isNight;// true∏È ≥∑
    [SerializeField] Material mat;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Light[] lights = GameObject.FindObjectsOfType<Light>();
        int count = lights.Length;
        for(int i = 0; i < count; i++) 
        { 
            Light light = lights[i];
            if(light.type == LightType.Directional)
            {
                lightDirctional = light;
                break;
            }
        }
    }


    void Start()
    {
        
    }
    void Update()
    {
            time %= 24;
        if(auto == true)
        {
            time += Time.deltaTime;
        }
        else
        {
            if(isNight == true && time != 13f)
            {


            }
        }
        checkisNight();
        updateLightin();

    }
    void checkisNight()
    {
        if(time > 20 || time < 6)
        {
            mat.EnableKeyword("_EMISSION");
        }
        else
        {
            mat.DisableKeyword("_EMISSION");
        }
    }

    void updateLightin()
    {
        if (lightDirctional == null) return;
        float timePercent = time / 24;
        Vector3 surRotatino = new Vector3(timePercent * 360-110,-30,0);
        lightDirctional.transform.localRotation = Quaternion.Euler(surRotatino);
    }
}
