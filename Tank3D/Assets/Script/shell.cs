using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shell : MonoBehaviour
{
    public GameObject shellExplosionPrefab; // ���ڵ����ӵ�������Ч
    public float time; // �ӵ�����ʱ������
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collider) // �ӵ���ײ�¼� �����shell�������ײ��⣨is trigger�� �����shellexplos��play on awakeʹ����ʵ�������Զ�����
    {
        GameObject.Instantiate(shellExplosionPrefab, transform.position, transform.rotation); // ʵ�����ӵ���ը����
        //GameObject.Destroy(this.gameObject); // �����ӵ����� �ð汾���Զ����� ����ע������

        if(collider.tag == "Tank")
        {
            // ������ײ�����TankDamage����
            collider.SendMessage("TankDamage",null,SendMessageOptions.DontRequireReceiver);
        }
    }
}
