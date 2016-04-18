using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void CambiarNivel()
    {
        SceneManager.LoadScene("Level");
    }

}
