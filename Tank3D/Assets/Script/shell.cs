using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shell : MonoBehaviour
{
    public GameObject shellExplosionPrefab; // 用于调用子弹销毁特效
    public float time; // 子弹销毁时间设置
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collider) // 子弹碰撞事件 必须打开shell对象的碰撞检测（is trigger） 必须打开shellexplos的play on awake使其在实例化后自动播放
    {
        GameObject.Instantiate(shellExplosionPrefab, transform.position, transform.rotation); // 实例化子弹爆炸特性
        //GameObject.Destroy(this.gameObject); // 销毁子弹对象 该版本会自动销毁 所以注销掉了

        if(collider.tag == "Tank")
        {
            // 调用碰撞对象的TankDamage函数
            collider.SendMessage("TankDamage",null,SendMessageOptions.DontRequireReceiver);
        }
    }
}
