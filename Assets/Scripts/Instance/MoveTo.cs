using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] Transform targetAgent;
    [SerializeField] float time;
    [SerializeField] float time2;
    [SerializeField] float distance;
    [SerializeField] float distanceEnemy;
    [SerializeField] bool onAwake;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (onAwake)
        {
            agent.SetDestination(targetAgent.position);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!onAwake)
        {
            time += Time.deltaTime;
            distance = Vector3.Distance(transform.position, targetAgent.position);
            if (time > time2 && distance > distanceEnemy)
            {

                agent.speed = 10;
                agent.SetDestination(targetAgent.position);
            }
            else if (distance <= distanceEnemy)
            {
                time = 0;
                agent.speed = 0;
            }
        }
    }
}
