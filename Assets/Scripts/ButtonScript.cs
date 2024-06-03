using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
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
        // �ڵ����ťʱ����ָ���ĳ�����03step1��
        SceneManager.LoadScene("03step1");
    }
}
