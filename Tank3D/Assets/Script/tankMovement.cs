using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class tankMovement : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float id = 1; // 玩家编号 区分控制
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()// 在固定帧调用 可放置位移操作
    {
        float v = Input.GetAxis("VerticalPlayer"+id); // 获取前后位置 -1到1对应向后到向前
        rigidbody.velocity = transform.forward * v * 8; // 前后移动 速度为8单位每秒

        float h = Input.GetAxis("HorizontalPlayer"+id); // 获取水平位置
        rigidbody.angularVelocity = transform.up * h * 8; // 围绕y轴旋转8单位
    }
}
