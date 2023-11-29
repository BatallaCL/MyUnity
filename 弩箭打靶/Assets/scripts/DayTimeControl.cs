using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTime : MonoBehaviour
{
    public float OrbitMinute = 0.1f;      //太阳转一周，所需的时间设为24分钟
    private float AnglePerSec = 0;

    //Real Time
    [Range(0, 1440)]
    public float sec = 0;
    private float min = 0;

    public DefaultTime defaultTime = DefaultTime.SystemTime;
    public enum DefaultTime
    {
        SystemTime,
        Random,
        Preset,
    }

    public float PresetTime = 7;

    [Header("Only Read")]
    //Game Time
    public float GameHour = 0;
    public float GameMin = 0;

    // Start is called before the first frame update
    void Start()
    {
        AnglePerSec = 360 / OrbitMinute / 60;
        if (defaultTime == DefaultTime.SystemTime)
            SetTime(System.DateTime.Now.Hour);
        else if (defaultTime == DefaultTime.Random)
            SetTime(Random.Range(0, 24));
        else if (defaultTime == DefaultTime.Preset)
            SetTime(PresetTime);
    }

    // Update is called once per frame
    void Update()
    {
        sec += Time.deltaTime;
        min = sec / 60;
        GameHour = (int)min % OrbitMinute;
        GameMin = (int)sec % 60;

        gameObject.transform.rotation = Quaternion.Euler(SunAngle(GameHour, GameMin), -90, 0);
    }

    float SunAngle(float hour)
    {
        return 360 / OrbitMinute * hour - 90;
    }

    float SunAngle(float hour, float minute)
    {
        return 360 / OrbitMinute * hour - 90 + AnglePerSec * minute;
    }

    void SetTime(float hour)
    {
        sec = hour * 60;
    }

}
