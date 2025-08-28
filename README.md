# Aryans_Onspot

public class MainMenuController : MonoBehaviour
{
    // Method to load the Game scene when Play is clicked
    public void PlayGame()
    {
        SceneManager.LoadScene("Game"); // Load the scene named "Game"
    }

    // Method to exit the application
    public void ExitGame()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }

    // Method to show instructions (you could show a UI panel here)
    
}
