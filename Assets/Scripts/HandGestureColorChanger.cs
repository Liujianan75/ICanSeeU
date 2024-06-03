using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using MixedReality.Toolkit.Input;
using MixedReality.Toolkit;


public class HandGestureColorChanger : MonoBehaviour
{
    public Renderer testPlaneRenderer;    // 用于显示颜色变化的平面的渲染器

    public float darkenSpeed = 1.0f;      // 变黑的速度
    public float lightenSpeedMultiplier = 0.1f; // 变白的速度与变黑的速度比例，这里设置为0.1，即变白的速度是变黑速度的1/10

    private Color targetColor = Color.white * 0.6f; // 目标颜色为60%灰度的白色

    private MRTKHandsAggregatorSubsystem aggregator;
    private bool isHandGestureActive = false;  // 手势是否激活
    private float releaseTimer = 0f;           // 释放手势后的计时器

    void Start()
    {
        // 获取TestPlane的渲染器组件
        if (testPlaneRenderer == null)
        {
            testPlaneRenderer = GetComponent<Renderer>();
        }
        StartCoroutine(EnableWhenSubsystemAvailable());
    }

    private IEnumerator EnableWhenSubsystemAvailable()
    {
        yield return new WaitUntil(() => (aggregator = XRSubsystemHelpers.GetFirstRunningSubsystem<MRTKHandsAggregatorSubsystem>()) != null);
    }

    void Update()
    {
        if (aggregator != null)
        {
            if (CheckHandGesture(XRNode.RightHand))
            {
                isHandGestureActive = true;
                releaseTimer = 0f;
            }
            else
            {
                isHandGestureActive = false;
                releaseTimer += Time.deltaTime;
            }

            if (isHandGestureActive)
            {
                Color currentColor = testPlaneRenderer.material.GetColor("_EmissionColor");  // 获取当前自发光颜色
                // 手势激活时，颜色逐渐变黑
                currentColor = Color.Lerp(currentColor, Color.black, Time.deltaTime * darkenSpeed);
                testPlaneRenderer.material.SetColor("_EmissionColor", currentColor);  // 更新自发光颜色
            }
            else if (releaseTimer >= darkenSpeed * 5)
            {
                Color currentColor = testPlaneRenderer.material.GetColor("_EmissionColor");  // 获取当前自发光颜色
                // 手势松开后，颜色逐渐变为目标颜色
                currentColor = Color.Lerp(currentColor, targetColor, Time.deltaTime * darkenSpeed * lightenSpeedMultiplier);
                testPlaneRenderer.material.SetColor("_EmissionColor", currentColor);
            }
        }
    }

    private bool CheckHandGesture(XRNode handNode)
    {
        float gestureThreshold = 0.03f; // 距离阈值为3厘米

        // 获取拇指和其他手指尖的位置
        if (aggregator.TryGetJoint(TrackedHandJoint.ThumbTip, handNode, out HandJointPose thumbPose) &&
            aggregator.TryGetJoint(TrackedHandJoint.IndexTip, handNode, out HandJointPose indexPose) &&
            aggregator.TryGetJoint(TrackedHandJoint.MiddleTip, handNode, out HandJointPose middlePose) &&
            aggregator.TryGetJoint(TrackedHandJoint.RingTip, handNode, out HandJointPose ringPose) &&
            aggregator.TryGetJoint(TrackedHandJoint.LittleTip, handNode, out HandJointPose littlePose))
        {
            // 检查拇指与其他手指尖的距离是否都小于阈值
            return Vector3.Distance(thumbPose.Position, indexPose.Position) < gestureThreshold &&
                   Vector3.Distance(thumbPose.Position, middlePose.Position) < gestureThreshold &&
                   Vector3.Distance(thumbPose.Position, ringPose.Position) < gestureThreshold &&
                   Vector3.Distance(thumbPose.Position, littlePose.Position) < gestureThreshold;
        }
        return false;
    }
}
