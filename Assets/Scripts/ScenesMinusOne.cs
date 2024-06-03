using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesMinusOne : MonoBehaviour
{
    // ��Inspector�����н���ť��ק������ֶ�
    public Button yourButton;

    void Start()
    {
        // ����ť��ӵ���¼�����
        yourButton.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        // �ڵ����ťʱ����-1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}

