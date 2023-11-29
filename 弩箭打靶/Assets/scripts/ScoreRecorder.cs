using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRecorder : MonoBehaviour
{
    public FireControl A;
    public int score;
    public Text scoreText;  //显示分数UI
    public Text fireText;  //显示射击状态UI
    public Text arrowNumText;  //显示弓箭数量UI
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    private void Update()
    {
        if((A.transform.position.x>=20 && A.transform.position.x <= 70) && (A.transform.position.z>=10 && A.transform.position.z<=25))
        //if(true)
        {
            A.fire_permisssion = true;
            fireText.text = "射击：允许";
            arrowNumText.text = "次数："+A.arrow_num;
        }
        else
        {
            A.fire_permisssion = false;
            fireText.text = "射击：禁止";
            arrowNumText.text = "次数：" + A.arrow_num;
        }
    }
    // Update is called once per frame
    public void RecordScore(int ringscore)
    {
        //增加新的值
        score += ringscore;
        scoreText.text = "分数：" + score;
    }
}
