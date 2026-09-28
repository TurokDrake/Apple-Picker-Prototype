using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    // 静态成员变量，规定的是苹果下落至这个距离以下时会被销毁，避免场景中太多苹果实例
    public static float bottomY = -20f;
    // ApplePicker的脚本引用
    public ApplePicker apScript;

    private void Start()
    {
        // 在开始前一帧获取ApplePicker的引用
        apScript = Camera.main.GetComponent<ApplePicker>();
    }

    void Update()
    {
        // 当苹果下落至这么远的位置时，销毁这个苹果
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            //ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            // 告诉ApplePicker脚本，我这个苹果销毁了，该执行你那边的逻辑了
            apScript.AppleDestroyed();
        }


    }
}
