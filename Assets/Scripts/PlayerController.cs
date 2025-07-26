using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    [SerializeField] private bool _isWASD = false;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isWASD)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(h, 0, v).normalized;

            _navMeshAgent.velocity = direction * _navMeshAgent.speed; // <- dato che i NavMeshAgent HANNO GIÀ IL PARAMETRO per la velocità, non mi occorre passarla dall`esterno
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // <- crea un raggio che parte dalla camera fino a dove clicco con il mouse
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) // <- mette l`info del target colpito in un raycast hit
                    _navMeshAgent.SetDestination(hit.point);
            }
        }
    }
}
