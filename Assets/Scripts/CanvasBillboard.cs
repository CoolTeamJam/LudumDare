using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasBillboard : MonoBehaviour
{
    Camera cam;

    private void Start()
    {
        GameObject[] SceneObjects = SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (GameObject sceneObject in SceneObjects)
        {
            if(sceneObject.name.CompareTo("Player") == 0)
            {
                cam = sceneObject.GetComponentInChildren<Camera>();
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(cam != null)
        {
            transform.rotation = cam.transform.rotation;
        }
    }
}
