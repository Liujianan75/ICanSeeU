using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Renderer testPlaneRenderer;    // 用于显示颜色变化的平面的渲染器

    public float darkenSpeed = 1.0f;      // 变黑的速度
    public float lightenSpeedMultiplier = 0.1f; // 变白的速度与变黑的速度比例，这里设置为0.33，即变白的速度是变黑速度的1/3

    private Color targetColor = Color.white * 0.6f; // 目标颜色为60%灰度的白色

    private bool isPressing = false;      // 是否正在长按
    private bool isButtonReleased = false; // 是否按钮被释放

    private float releaseTimer = 0f;       // 释放按钮后的计时器

    void Start()
    {
        // 获取TestPlane的渲染器组件
        if (testPlaneRenderer == null)
        {
            testPlaneRenderer = GetComponent<Renderer>();
        }
    }

    void Update()
    {
        if (isPressing)
        {
            Color currentColor = testPlaneRenderer.material.GetColor("_EmissionColor");  // 获取当前自发光颜色

            // 按下按钮时，颜色逐渐变黑
            currentColor = Color.Lerp(currentColor, Color.black, Time.deltaTime * darkenSpeed);

            testPlaneRenderer.material.SetColor("_EmissionColor", currentColor);  // 更新自发光颜色
        }
        else if (isButtonReleased)
        {
            // 按钮被释放后开始计时
            releaseTimer += Time.deltaTime;

            // 等待三倍时间后开始变白
            if (releaseTimer >= darkenSpeed * 5)
            {
                Color currentColor = testPlaneRenderer.material.GetColor("_EmissionColor");  // 获取当前自发光颜色

                // 松开按钮后，颜色逐渐变为目标颜色，速度是变黑速度的三分之一
                currentColor = Color.Lerp(currentColor, targetColor, Time.deltaTime * darkenSpeed * lightenSpeedMultiplier);

                testPlaneRenderer.material.SetColor("_EmissionColor", currentColor);  // 更新自发光颜色
            }
        }
    }

    // 当按钮被按下时触发的方法
    public void OnButtonPressed()
    {
        isPressing = true;
        isButtonReleased = false;
        releaseTimer = 0f; // 重置释放按钮的计时器
    }

    // 当按钮被释放时触发的方法
    public void OnButtonReleased()
    {
        isPressing = false;
        isButtonReleased = true;
    }
}
