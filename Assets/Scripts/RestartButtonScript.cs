using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonScript : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(0).name);

    }
}
