using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinusOne : MonoBehaviour
{

    long count;
    bool toCount = false;

  

    public void TaskOnClick()
    {
        // �ڵ����ťʱ����-1
        if (count == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            toCount = true;
        }
    }
         
    void Updata()
    {
        if (toCount)
        {
          count++;
          if (count > 270)
          {
            count = 0;
            toCount = false;
          }
        }
    }
}