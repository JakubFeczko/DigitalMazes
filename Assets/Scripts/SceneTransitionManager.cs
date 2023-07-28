using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class manages scene transitions, including both synchronous and asynchronous scene loading.
/// </summary>
public class SceneTransitionManager : MonoBehaviour
{
    /// <summary>
    /// The screen fading effect used during scene transitions.
    /// </summary>
    public FadeScreen fadeScreen;

    /// <summary>
    /// The singleton instance of the SceneTransitionManager.
    /// </summary>
    public static SceneTransitionManager singleton;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        if (singleton && singleton != this)
            Destroy(singleton);

        singleton = this;
    }

    /// <summary>
    /// Go to a specified scene synchronously.
    /// </summary>
    /// <param name="sceneIndex">The build index of the scene to go to.</param>
    public void GoToScene(int sceneIndex)
    {
        StartCoroutine(GoToSceneRoutine(sceneIndex));
    }

    /// <summary>
    /// Coroutine that handles the process of fading out the screen and synchronously loading a new scene.
    /// </summary>
    /// <param name="sceneIndex">The build index of the scene to go to.</param>
    IEnumerator GoToSceneRoutine(int sceneIndex)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);

        //Launch the new scene
        SceneManager.LoadScene(sceneIndex);
    }

    /// <summary>
    /// Go to a specified scene asynchronously.
    /// </summary>
    /// <param name="sceneIndex">The build index of the scene to go to.</param>
    public void GoToSceneAsync(int sceneIndex)
    {
        StartCoroutine(GoToSceneAsyncRoutine(sceneIndex));
    }

    /// <summary>
    /// Coroutine that handles the process of fading out the screen and asynchronously loading a new scene.
    /// </summary>
    /// <param name="sceneIndex">The build index of the scene to go to.</param>
    IEnumerator GoToSceneAsyncRoutine(int sceneIndex)
    {
        fadeScreen.FadeOut();
        //Launch the new scene
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        float timer = 0;
        while(timer <= fadeScreen.fadeDuration && !operation.isDone)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        operation.allowSceneActivation = true;
    }
}
