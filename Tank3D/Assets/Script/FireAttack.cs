using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour
{
    public GameObject shell; // 用于应用子弹实例
    public KeyCode FireKey = KeyCode.Space; // 发射键位设置 默认空格键
    private Transform FirePosition; // 发射位置
    public float shellspeed = 15;
    // Start is called before the first frame update
    void Start()
    {
        FirePosition = transform.Find("FirePosition"); // 获取发射位置 应用之前创建的empty对象
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(FireKey)) // 按下keycode时
        {
            GameObject go = GameObject.Instantiate(shell, FirePosition.position, FirePosition.rotation) as GameObject; // 实例化子弹到fireposition位置 旋转角度也保持一致
            go.GetComponent<Rigidbody>().velocity = go.transform.forward * shellspeed; // 给予子弹向前发射的速度
        }
    }
}
