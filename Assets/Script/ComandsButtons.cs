using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.SceneManagement;

public class ComandsButtons : MonoBehaviour
{
    // Start is called before the first frame update

    public void ToScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
 
}
