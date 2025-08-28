using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleLevelSelector : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}