using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader 
{
    public static void LoadScene(int targetScene) => SceneManager.LoadScene(targetScene);
    public static void RestartScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public static void QuitGame () => Application.Quit();

    public static IEnumerator AsynLoadScene(int whatScene, float howLongToWait)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(whatScene); //Ready to load scene
        asyncLoad.allowSceneActivation = false; //So it not load scene before the time have gone

        yield return new WaitForSeconds(howLongToWait);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            asyncLoad.allowSceneActivation = true; //Load scene
            yield return null;
        }
    }
}
