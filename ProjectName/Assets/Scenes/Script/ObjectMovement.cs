using UnityEngine;
using UnityEngine.AI;

public class ObjectMovement : MonoBehaviour
{
    public Transform[] points; // ������ ����� �����������
    private int currentPointIndex = 0;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToNextPoint();
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
}