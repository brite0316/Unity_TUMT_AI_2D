using UnityEngine;
using UnityEngine.SceneManagement; //引用 場景管理 API

public class GameManager : MonoBehaviour
{
    public void Reset()
    {
        //Application.LoadLevel("遊戲");
        SceneManager.LoadScene("遊戲");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

   

