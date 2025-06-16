using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour
{
    public void GoStage(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
