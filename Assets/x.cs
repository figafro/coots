using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class x : MonoBehaviour
{
    private void OnMouseDrag()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
