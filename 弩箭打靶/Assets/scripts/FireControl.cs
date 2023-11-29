using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    public bool fire_permisssion = true;
    public int arrow_num = 10;

    public ArrowControl arrow; //箭模板
    public Animator animator; //动画组件
    public Transform arrowPoint; //发射箭点

    public Transform bow_tem; //弓箭模板
    public Transform bow; //弓箭竖直
    public Transform bow_ro; //弓箭水平
    public float bow_rato = .1f; //竖直旋转速度
    public float ro_rato = .1f; //水平旋转速度

    public float hold_power; //蓄力强度
    public AnimationCurve hold_curve; //蓄力强度变化曲线
    public Vector3 mouse_position; //鼠标位置
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
            //弓箭发射事件 左键控制 点下长按蓄力 松开后发射
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
        
        //弓箭视角变化
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
