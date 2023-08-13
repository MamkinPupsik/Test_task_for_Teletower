using UnityEngine;
using UnityEngine.AI;

public class ObjectMovement : MonoBehaviour
{
    public Transform[] points; // ������ ����� �����������
    private int currentPointIndex = 0;
    private NavMeshAgent agent;
    public float startSpeed = 2f;
    public float RunSpeed = 2f;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        MoveToNextPoint();
        agent.speed = startSpeed;
    }

    private void Update()
    {
        // ���������, ������ �� ������ ������� ����� �����������
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            MoveToNextPoint();
        }
    }

    private void MoveToNextPoint()
    {
        // ������������� ����� ���� �����������
        // ��������� � ��������� ����� ��� ������������ � ������, ���� �������� ����� ������� �����
        agent.SetDestination(points[currentPointIndex].position);
        currentPointIndex = (currentPointIndex + 1) % points.Length;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("goRun"))
        {
            anim.SetBool("isRuning", true);
            agent.speed += RunSpeed;
        }

        if(other.CompareTag("goWalk"))
        {
            anim.SetBool("isRuning", false);
            agent.speed = startSpeed;
        }
    }
}