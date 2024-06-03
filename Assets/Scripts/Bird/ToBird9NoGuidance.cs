using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToBird9NoGuidance : MonoBehaviour
{

    long count;
    bool toCount = false;


    public void OnLoginButtonClick()
    {
        if (count == 0)
        {
            SceneManager.LoadScene("Bird9.1.0NoGuidance");
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
