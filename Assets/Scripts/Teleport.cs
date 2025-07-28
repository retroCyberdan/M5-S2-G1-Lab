using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleport : MonoBehaviour
{
    [SerializeField] Transform _teleportPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out NavMeshAgent agent)) agent.Warp(_teleportPoint.position); // <- metodo dei NavMeshAgent per teletrasportare in un punto (assegnre la transform di un punto da Inspector)
    }
}
