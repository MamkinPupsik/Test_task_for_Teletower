using UnityEngine;
using UnityEngine.AI;

public class ObjectMovement : MonoBehaviour
{
    public Transform[] points; // Массив точек перемещения
    private int currentPointIndex = 0;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToNextPoint();
    }

    private void Update()
    {
        // Проверяем, достиг ли объект текущей точки перемещения
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            MoveToNextPoint();
        }
    }

    private void MoveToNextPoint()
    {
        // Устанавливаем новую цель перемещения
        // Переходим к следующей точке или возвращаемся к первой, если достигли конца массива точек
        agent.SetDestination(points[currentPointIndex].position);
        currentPointIndex = (currentPointIndex + 1) % points.Length;
    }
}