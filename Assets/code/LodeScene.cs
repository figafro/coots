using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LodeScene : MonoBehaviour
{
   public void lode(string name)
    {
        SceneManager.LoadScene(name);
    }
}
