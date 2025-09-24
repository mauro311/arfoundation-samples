using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] List<Transform> checkpoints = new();
    private int actualCheckpoint = 0;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        CheckpointsMovement();
    }

    public void CheckpointsMovement()
    {

        if (agent.remainingDistance <= agent.stoppingDistance)
        {

            agent.SetDestination(checkpoints[actualCheckpoint].position);
            actualCheckpoint++;
        }
        else if (actualCheckpoint >= checkpoints.Count)
        {
            actualCheckpoint = 0;
        }
    }
}
