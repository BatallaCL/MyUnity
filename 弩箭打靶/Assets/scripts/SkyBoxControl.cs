using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBControl : MonoBehaviour
{
    public Material[] mats;//天空盒数组
    private int index = 0;
    public int changeTime = 3 ;//更换天空盒子的秒数
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(System.DateTime.Now.Hour);
        InvokeRepeating("ChangeBox", 0, changeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeBox()
    {

        RenderSettings.skybox = mats[index];
        index++;
        index %= mats.Length;
    }
}
