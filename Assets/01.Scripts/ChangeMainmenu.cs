using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMainmenu : MonoBehaviour
{

    public void SceneChange()
    {
        SceneManager.LoadScene("GameTitle");
    }
}