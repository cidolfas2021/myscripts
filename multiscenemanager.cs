using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class multiscenemanager : MonoBehaviour
{
    public Text m_Text;
    public GameObject Button;
    private AsyncOperation asyncOperation;

    // Start is called before the first frame update
    void Start()
    {
        // Disable the button at the start
        Button.SetActive(false);
        // Start loading the scene asynchronously
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        // Create an asynchronous operation to load the scene
        asyncOperation = SceneManager.LoadSceneAsync("GameZero");
        // Don't let the scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;

        // While the scene is not done loading
        while (!asyncOperation.isDone)
        {
            // Output the current loading progress
            m_Text.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";

            // Check if the load has reached 90%
            if (asyncOperation.progress >= 0.9f)
            {
                m_Text.text = "";
                // Enable the button when the loading is almost complete
                Button.SetActive(true);
            }

            yield return null;
        }
    }

    // Change scene function
    public void ChangeScene(string sceneName)
    {
        // Only allow scene activation when the button is pressed
        asyncOperation.allowSceneActivation = true;
    }

    // Exit the application
    public void Exit()
    {
        Application.Quit();
    }
}