using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    // 最高分
    public static int score = 1000;
    // 最高分的文本控件，这里是UGUI中的Text
    public Text highScore;


    private void Awake()
    {
        // 如果之前存过这个数据，就把这个数据拿出来（读取数据）
        // PlayerrPrefs保存的数据在注册表里能看到
        if (PlayerPrefs.HasKey("ApplePickerHighScore"))
        {
            score = PlayerPrefs.GetInt("ApplePickerHighScore");
        }
        //PlayerPrefs.SetInt("ApplePickerHighScore", score);
    }
    // Start is called before the first frame update
    void Start()
    {
        // 在前一帧获取文本控件的引用
        highScore = this.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        // 更新UI控件文本的逻辑
        highScore.text = "High Score: " + score;
        // 如果最高分超过历史记录，就再保存一次
        if (score > PlayerPrefs.GetInt("ApplePickerHighScore"))
        {
            PlayerPrefs.SetInt("ApplePickerHighScore", score);
        }
    }

}
