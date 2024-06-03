using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoOn1 : MonoBehaviour
{

    long count;
    bool toCount = false;


    public void OnLoginButtonClick()
    {
        if (count == 0)
        {
            SceneManager.LoadScene("ChooseBirdNoGuidance");
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
