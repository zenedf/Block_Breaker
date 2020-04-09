using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // Creates a 'SceneLoader' to load a scene using this script.
    SceneLoader loader = new SceneLoader();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            loader.LoadStartScene();
        }
    }
}
