using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Canvas))]
public class ConnectToCamera : MonoBehaviour
{
    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        SceneManager.sceneLoaded += OnSceneLoad;
        SceneManager.sceneUnloaded += OnSceneUnload;
    }

    private void OnSceneUnload(Scene scene)
    {
        canvas.enabled = false;
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        GameObject cameraContainer = GameObject.FindWithTag("MainCamera");
        Camera camera;
        if(!cameraContainer || !cameraContainer.TryGetComponent(out camera))
        {
            // Error Handle here.
            Debug.LogError("Could not find a camera on object tagged 'Main Camera'!");
            return;
        }
        canvas.worldCamera = camera;
        canvas.enabled = true;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoad;
        SceneManager.sceneUnloaded -= OnSceneUnload;
    }
}
