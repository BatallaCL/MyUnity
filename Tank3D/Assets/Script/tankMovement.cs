using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class tankMovement : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float id = 1; // ��ұ�� ���ֿ���
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()// �ڹ̶�֡���� �ɷ���λ�Ʋ���
    {
        float v = Input.GetAxis("VerticalPlayer"+id); // ��ȡǰ��λ�� -1��1��Ӧ�����ǰ
        rigidbody.velocity = transform.forward * v * 8; // ǰ���ƶ� �ٶ�Ϊ8��λÿ��

        float h = Input.GetAxis("HorizontalPlayer"+id); // ��ȡˮƽλ��
        rigidbody.angularVelocity = transform.up * h * 8; // Χ��y����ת8��λ
    }
}
