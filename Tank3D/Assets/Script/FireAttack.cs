using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour
{
    public GameObject shell; // ����Ӧ���ӵ�ʵ��
    public KeyCode FireKey = KeyCode.Space; // �����λ���� Ĭ�Ͽո��
    private Transform FirePosition; // ����λ��
    public float shellspeed = 15;
    // Start is called before the first frame update
    void Start()
    {
        FirePosition = transform.Find("FirePosition"); // ��ȡ����λ�� Ӧ��֮ǰ������empty����
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(FireKey)) // ����keycodeʱ
        {
            GameObject go = GameObject.Instantiate(shell, FirePosition.position, FirePosition.rotation) as GameObject; // ʵ�����ӵ���firepositionλ�� ��ת�Ƕ�Ҳ����һ��
            go.GetComponent<Rigidbody>().velocity = go.transform.forward * shellspeed; // �����ӵ���ǰ������ٶ�
        }
    }
}
