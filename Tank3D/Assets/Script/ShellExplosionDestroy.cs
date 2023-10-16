using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellExplosionDestroy : MonoBehaviour
{
    public float time; // 设置为该特效的播放时间1.5s

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
