using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UITest : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //����
        GetComponent<Image>().color = Color.red;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //̧��
        GetComponent<Image>().color = Color.white;
    }

    public void StartMenu()
    {
        SceneManager.LoadScene(1);


    }
}