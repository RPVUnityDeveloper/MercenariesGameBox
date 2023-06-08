using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}