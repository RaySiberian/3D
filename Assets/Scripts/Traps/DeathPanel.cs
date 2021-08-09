using UnityEngine;

public class DeathPanel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Player>().GetDamage();
    }
}
