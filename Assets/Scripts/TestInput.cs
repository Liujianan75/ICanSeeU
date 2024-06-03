using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class TestInput : MonoBehaviour
{
    
    [Header("Key Binding")]
    [SerializeField]
    InputActionProperty m_XKeyAction = new InputActionProperty(new InputAction("X", type: InputActionType.Button));
    
    // Start is called before the first frame update
    void Start()
    {
        m_XKeyAction.EnableDirectAction();
        m_XKeyAction.action.performed += (ob) =>
        {
            Application.Quit();
        };
    }

    void OnDestroy()
    {
        m_XKeyAction.DisableDirectAction();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
