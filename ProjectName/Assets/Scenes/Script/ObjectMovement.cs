using UnityEngine;
using UnityEngine.AI;
public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private Transform[] points; // Массив точек перемещения
    [SerializeField] private int currentPointIndex = 0;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private bool check = false;
    [SerializeField] private float increasedSpeed = 1f;
    [SerializeField] private float startSpeed = 2.5f;
    [SerializeField] private Animator anim;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToNextPoint();
        agent.speed = startSpeed;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {   
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            MoveToNextPoint();
        }
    }

    private void MoveToNextPoint()
    {
        
        agent.SetDestination(points[currentPointIndex].position);
        currentPointIndex = (currentPointIndex + 1) % points.Length;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerRun")) 
        {
            anim.SetBool("isRunning", true);
            agent.speed += increasedSpeed; 
        }

        if (other.CompareTag("TriggerWalk")) 
        {
            if (agent.speed == startSpeed)
            {
                agent.speed = startSpeed;
            }
            else
            {
                anim.SetBool("isRunning", false);
                agent.speed -= increasedSpeed;
            }
        }
    }


}