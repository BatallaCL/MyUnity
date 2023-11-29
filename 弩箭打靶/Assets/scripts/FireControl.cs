using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    public bool fire_permisssion = true;
    public int arrow_num = 10;

    public ArrowControl arrow; //��ģ��
    public Animator animator; //�������
    public Transform arrowPoint; //�������

    public Transform bow_tem; //����ģ��
    public Transform bow; //������ֱ
    public Transform bow_ro; //����ˮƽ
    public float bow_rato = .1f; //��ֱ��ת�ٶ�
    public float ro_rato = .1f; //ˮƽ��ת�ٶ�

    public float hold_power; //����ǿ��
    public AnimationCurve hold_curve; //����ǿ�ȱ仯����
    public Vector3 mouse_position; //���λ��
    // Start is called before the first frame update
    void Start()
    {
        animator = bow_tem.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   if(fire_permisssion == true && arrow_num>0)
        //if(true)
        {
            //���������¼� ������� ���³������� �ɿ�����
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                hold_power = 0;
                animator.SetBool("pull", true);
            }
            if (Input.GetKey(KeyCode.Mouse0))
            {
                animator.SetBool("hold", true);
                if (Time.deltaTime <= 3)
                {
                    hold_power += Time.deltaTime;
                    animator.SetFloat("hold_power", 0.7f - hold_power);
                }
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                animator.SetBool("pull", false);
                animator.SetBool("hold", false);
                animator.SetBool("shoot", true);
                ArrowControl temp = Instantiate(arrow, arrowPoint.position, arrowPoint.rotation);
                temp.force = hold_curve.Evaluate(hold_power);
                animator.SetBool("shoot", false);
                animator.SetFloat("hold_power", 0.5f);
                arrow_num--;
            }

        }
        
        //�����ӽǱ仯
        if(Input.GetKeyDown (KeyCode.Mouse1))
        {
            mouse_position = Input.mousePosition;
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            bow_ro.Rotate( - Vector3.up * (mouse_position - Input.mousePosition).x * ro_rato);
            bow.Rotate(Vector3.right*(mouse_position - Input.mousePosition).y * bow_rato);
        }
        mouse_position = Input.mousePosition;
    }
}
