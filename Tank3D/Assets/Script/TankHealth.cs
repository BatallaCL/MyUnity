using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    public int hp = 100;
    public GameObject tankExplosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0) // ��̹���ܵ������˺� ����tankExplosion��Ч��ͬ��Ҫ�ǵù�ѡplay on awake��
        {
            // ����tankExplosion��Ч
            GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);
            GameObject.Destroy(this.gameObject);
        }
    }

    void TankDamage()
    {
        if (hp <= 0) return;
        hp -= Random.Range(10, 20);
    }
}
