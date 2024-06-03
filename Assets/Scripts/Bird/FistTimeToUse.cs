using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FistTimeToUse : MonoBehaviour
{
   
    public void OnLoginButtonClick()
    {
        SceneManager.LoadScene("ChooseLevel");
        
    }
}
