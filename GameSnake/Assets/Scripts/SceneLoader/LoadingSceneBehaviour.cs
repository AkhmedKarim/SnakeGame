using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingSceneBehaviour : MonoBehaviour
{
    public Animator animator;
    AsyncOperation operation;

    public void LoadingScen(SceneLoader.Scene scene)
    {
        operation = SceneManager.LoadSceneAsync(scene.ToString());
        operation.allowSceneActivation = false;

        Appear();
    }

    public void AllowSceneActivation()
    {
        operation.allowSceneActivation = true;
    }

    private void Appear()
    {
        animator.SetTrigger("Appear");
    }

}
