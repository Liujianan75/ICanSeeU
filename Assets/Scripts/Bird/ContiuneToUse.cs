using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContiuneToUse : MonoBehaviour
{

    public void OnLoginButtonClick()
    {
        SceneManager.LoadScene("ChooseBird");

    }
}
