using UnityEngine;
using UnityEngine.InputSystem;

// 1. You must include this namespace
using UnityEngine.SceneManagement; 

public class SceneReloader : MonoBehaviour
{
    void Update()
    {
        // Press "R" to reload the scene
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            ReloadCurrentScene();
        }
    }

    public void ReloadCurrentScene()
    {
        // 2. Fetch the active scene, then get its buildIndex or name
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        // 3. Load it again
        SceneManager.LoadScene(currentSceneIndex);
    }
}
