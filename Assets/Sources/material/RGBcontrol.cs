using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGBcontrol : MonoBehaviour
{
    public bool Pause = false;
    public Material TargetMaterial;
    public float ChangingSpeed = 0.5f; // 进一步降低颜色变化速度
    public float ColorTransitionSpeed = 0.0025f; // 调整颜色过渡的速度

    private Color LightGreen = new Color(0.721f, 0.858f, 0.541f); // B8DB8A颜色的浅绿
    private Color DarkGreen = new Color(0.164f, 0.22f, 0.086f); // 293816颜色的深绿
    private float GreenValue = 0.0f;
    private float TransitionDirection = 1.0f;

    void Update()
    {
        if (GreenValue > 1.0f)
        {
            GreenValue = 1.0f;
        }
        if (GreenValue < 0.0f)
        {
            GreenValue = 0.0f;
        }

        if (Pause == false)
        {
            // 使用Lerp函数在浅绿色和深绿色之间进行过渡
            TargetMaterial.SetColor("_RimLightColor", Color.Lerp(DarkGreen, LightGreen, GreenValue));

            GreenValue += TransitionDirection * ColorTransitionSpeed * ChangingSpeed;

            if (GreenValue >= 1.0f || GreenValue <= 0.0f)
            {
                TransitionDirection *= -1; // 反转颜色变化的方向
            }
        }
    }
}
