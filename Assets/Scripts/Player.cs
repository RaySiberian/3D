using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static event Action<Collider> Triggered;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneLoader.LoadFirstScene();
        }
        
        if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneLoader.LoadSecondScene();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Triggered?.Invoke(other);
    }
}
