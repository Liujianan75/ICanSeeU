using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesMinusOne : MonoBehaviour
{
    // 在Inspector窗口中将按钮拖拽到这个字段
    public Button yourButton;

    void Start()
    {
        // 给按钮添加点击事件监听
        yourButton.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        // 在点击按钮时场景-1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}

