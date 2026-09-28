using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // 苹果树预制体
    public GameObject applePrefab;

    public float speed = 1f; // 苹果树移动速度
    public float leftAndRightEdge = 10f; // 苹果树能移动的范围，只能左右移动不超过10格距离
    public float chanceToChangeDirections = 0.1f; // 改变方向的几率，0.1还是太大了
    public float secondsBetweenAppleDrops = 1f; // 苹果树掉落苹果的时间间隔

    private void Start()
    {
        // 令苹果树在2s后开始掉落苹果，每隔 secondsBetweenAppleDrops 秒掉落一次
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
    }

    private void Update()
    {
        // 获取苹果树的位置
        Vector3 pos = transform.position;
        // 每一帧都会在x方向位移
        pos.x += speed * Time.deltaTime; 
        // 更新苹果树的位置
        transform.position = pos;

        // 如果苹果树的位置超出了左边界或者右边界，就改变它的运动方向
        if (pos.x < -leftAndRightEdge)
        {
            // Mathf.Abs()能返回一个数的绝对值
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }

    }

    // 在FixedUpdate()中的逻辑会每隔固定帧数运行一次，放在Update()中有可能会频繁改变方向，所以放在这
    private void FixedUpdate()
    {
        // Random.value产生一个从0到1的浮点数，当这个随机数小于我们设定的改变方向的概率时，我们就让苹果树改变一个方向运动
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }

    // 掉落苹果的方法
    private void DropApple()
    {
        // 实例化一个苹果预制体
        GameObject apple = Instantiate(applePrefab) as GameObject;
        // 令苹果的位置和苹果树的位置重合
        apple.transform.position = transform.position;
    }
}
