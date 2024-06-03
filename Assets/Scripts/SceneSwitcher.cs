using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public Button switchSceneButton;

    void Start()
    {
        switchSceneButton.onClick.AddListener(SwitchSceneOnClick);
    }

    public void SwitchSceneOnClick()
    {
        Debug.Log("Button clicked! Switching scene..."); // 添加调试信息

        SceneManager.LoadScene("02scroll");
    }
}