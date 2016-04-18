using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour {

    public int numberOfShots = 0;

    void OnDestroy()
    {
        SceneManager.LoadScene("Win");
    }

}
