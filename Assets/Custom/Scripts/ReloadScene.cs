using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public PointManager pointManager; // drag this in the inspector

    public void Reload()
    {
        // Safety check
        if (pointManager != null)
        {
            pointManager.RegisterRun();
        }
        else
        {
            Debug.LogWarning("ReloadScene: PointManager reference not assigned!");
        }

        // Reload current scene
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);
    }
}
