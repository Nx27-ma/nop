using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    

    void Start()
    {
        TMP_InputField inputField;

        Canvas canvas = GetComponent<Canvas>();
        if (canvas != null)
        {
            
            foreach (Transform child in canvas.transform)
            {
                
                inputField = child.GetComponent<TMP_InputField>();
                if (inputField != null)
                {
                    
                    inputField.characterLimit = 1;
                }
                else
                {
                    Debug.LogWarning("No inputfield found");
                }
            }
        }
        else
        {
            Debug.LogWarning("No Canvas component found on the GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
