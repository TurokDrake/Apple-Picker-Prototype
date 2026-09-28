using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // 记录当前得分
    public static int curScore = 0;
    // 当前得分的文本控件
    public Text curScoreT;
    // Start is called before the first frame update
    void Start()
    {
        // 获取当前得分的文本控件
        curScoreT = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // 更新文本控件
        curScoreT.text = "Score: " + curScore.ToString();
    }

    // 退出时重置当前得分
    private void OnDestroy()
    {
        curScore = 0;
    }
}
