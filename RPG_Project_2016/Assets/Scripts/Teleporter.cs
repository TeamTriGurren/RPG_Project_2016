using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Teleporter : MonoBehaviour {

    public string levelToLoad;

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }

  
}
