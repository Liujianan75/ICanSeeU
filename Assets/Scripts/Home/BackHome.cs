using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackHome : MonoBehaviour
    {

        public void OnLoginButtonClick()
        {
            SceneManager.LoadScene("Start");

        }
    }
