using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static event Action<Collider> Triggered;

    private void OnTriggerEnter(Collider other)
    {
        Triggered?.Invoke(other);
    }
}
