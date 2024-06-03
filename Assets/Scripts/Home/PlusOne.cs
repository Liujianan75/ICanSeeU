using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlusOne : MonoBehaviour
{

    long count;
    bool toCount = false;

    public void TaskOnClick()
    {
        // 在点击按钮时场景+1
        if (count == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            toCount = true;
        }

    }

    void Update()
    {
        if (toCount)
        {
            count++;
            if(count > 270)
            {
                count = 0;
                toCount = false;
            }
        }
    }
}

