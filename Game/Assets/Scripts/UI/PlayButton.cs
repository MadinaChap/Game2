using UnityEngine;
using UnityEngine.SceneManagement;
public class Game : MonoBehaviour
{
    public void OpenGame(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }
}
