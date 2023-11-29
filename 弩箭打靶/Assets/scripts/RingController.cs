using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{
    //当前环的分值
    public  int RingScore = 0;
    public ScoreRecorder sc_recorder;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //碰撞检测，如果箭击中该环，就响应。
    void OnTriggerEnter(Collider temp)
    {
        //得到箭身
        Transform arrow = temp.gameObject.transform;
        if (temp == null)
        {
            return;
        }
        //有箭中靶
        if (temp.tag == "arrow")
        {
            //将箭的速度设为0
            arrow.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            //使用运动学运动控制
            arrow.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    void OnTriggerExit(Collider temp){
        //得到箭身
        Transform  arrow = temp.gameObject.transform;
        if(temp == null)
        {
            return ;
        }
        //有箭中靶
        if(temp.tag == "arrow"){
            //将箭的速度设为0
            arrow.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            //使用运动学运动控制
            arrow.GetComponent<Rigidbody>().isKinematic = true;
            //计分
            sc_recorder.RecordScore(RingScore);
            //标记箭为中靶
            //arrow.tag = "onTarget";
        }
    }
}
