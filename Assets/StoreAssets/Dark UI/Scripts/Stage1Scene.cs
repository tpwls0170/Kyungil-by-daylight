using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1Scene : MonoBehaviour
{
    // Start is called before the first frame update
 public void onClick()
    {
        SceneManager.LoadScene("Scene_A");
    }
}
