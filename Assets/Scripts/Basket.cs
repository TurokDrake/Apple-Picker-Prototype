using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    //public Text scoreGT;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject scoreGO = GameObject.Find("ScoreCounter");
        //scoreGT = scoreGO.GetComponent<Text>();
        //scoreGT.text = "HighScore:0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 检测与苹果的碰撞
    private void OnCollisionEnter(Collision collision)
    {
        // 获取检测到的碰撞体的对象
        GameObject collidedWith = collision.gameObject;
        // 判断碰撞体标签是不是“Apple”，如果是就把对方销毁
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
        }

        //int score = HighScore.score;
        // 每接到一个苹果，就+100分
        Score.curScore += 100;
        // 如果当前得分超过了最高分，就更新最高分的记录
        if (Score.curScore > HighScore.score)
        {
            HighScore.score = Score.curScore;
        }
    }
}
