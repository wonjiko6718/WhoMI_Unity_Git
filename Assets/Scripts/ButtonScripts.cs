using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour
{
    public void OnClickExit()
    {
        Application.Quit(); // if this button clicked, get exit application
    }
    public void OnClickStart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
