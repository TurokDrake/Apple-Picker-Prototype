using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    // 篮子的预制体
    public GameObject basketPrefab;

    //public GameObject[] tBasketGO;

    // 篮子数量，在这个游戏里相当于生命值
    public int numBaskets = 3;

    // 第一个（也是最下面的）篮子的位置，应该在编辑器中调整合适的位置
    public float basketBottomY = -14f;

    // 篮子间的距离
    public float basketSpacingY = 2f;

    // 放着所有篮子
    public List<GameObject> basketList;

    void Start()
    {
        // 先初始化列表
        basketList = new List<GameObject>();

        //tBasketGO = new GameObject[numBaskets];

        // 把三个篮子实例化到场景中
        for(int i = 0; i < numBaskets; i++)
        {
            //tBasketGO[i] = Instantiate(basketPrefab) as GameObject;

            // 实例化出一个篮子预制体
            GameObject tBasketGO = Instantiate(basketPrefab) as GameObject;
            // 先创建一个位于原点的位置
            Vector3 pos = Vector3.zero;
            // 根据当前篮子的序号，设定在Y方向上的位置
            pos.y = basketBottomY + (basketSpacingY * i);

            //tBasketGO[i].transform.position = pos;

            // 改变篮子的位置
            tBasketGO.transform.position = pos;

            //basketList.Add(tBasketGO[i]);

            // 将已经实例化的篮子添加到列表里
            basketList.Add(tBasketGO);
        }
    }

    void Update()
    {
        // 这里是实现鼠标控制篮子移动的功能

        // 获取鼠标位置，鼠标的位置是屏幕坐标，如果不设置，那么z方向的坐标就是0
        // 虽然变量命名为2D，其实是个三维坐标，只不过鼠标的位置不更改的话可以看出只有二维，因为鼠标只能在一个平面上移动
        Vector3 mousePos2D = Input.mousePosition;
        // 改变z方向的坐标，是为了让后面生成的篮子能被摄像机渲染
        mousePos2D.z = -Camera.main.transform.position.z;
        // 将屏幕坐标转化成世界坐标
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        // 获取第一个（序号为0）篮子的坐标，以后根据这个坐标为参考，来设置剩下的篮子的坐标
        Vector3 pos = basketList[0].transform.position;
        // 改变X方向的坐标
        pos.x = mousePos3D.x;
        // 如果篮子给销毁了，就不必进行下去了
        if (basketList.Count <= 0)
        {
            return;
        }
        // 为每个篮子设置Y方向的坐标
        for(int i = 0; i < basketList.Count; i++)
        {
            // 参考位置
            Vector3 waitForAlignPos = pos;
            // 根据序号，从下到上生成篮子
            pos.y = basketBottomY + (basketSpacingY * i);
            // 改变篮子的坐标
            basketList[i].transform.position = pos;
        }
    }

    // 苹果由于下落到-20以下的距离而被销毁，而不是用篮子接住而销毁时调用这个方法
    // 简单来说就是篮子没有接住苹果
    public void AppleDestroyed()
    {
        // 获取场景中剩下的苹果
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");

        // 把剩下的苹果一并销毁
        foreach(GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        // 因为没接住，所以有惩罚，销毁一个篮子，从上往下销毁
        // 之所以从上往下销毁篮子，是因为这样可以提高容错，最底下的篮子更容易接苹果
        int basketIndex = basketList.Count - 1;
        GameObject tBasketGO = basketList[basketIndex];
        // 需要移除列表中的对象
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        // 一旦篮子都销毁完了，就重新开一把
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
    }
}
