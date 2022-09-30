using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryShower : MonoBehaviour
{
    [SerializeField] private PlayerMove _move;
    private LineRenderer _lineRenderer;
    private List<Vector2> _targerPoints;

    private void Awake()
    {

        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.startWidth = 0.1f;
        _lineRenderer.endWidth = 0.1f;
        _targerPoints = new List<Vector2>() { transform.position };
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPosition(0, _targerPoints[0]);
    }

    private void FixedUpdate()
    {
        DefineLastPosition();
    }
    private void OnEnable()
    {
        _move.PointReached += AddTarget;
    }

    private void OnDisable()
    {
        _move.PointReached -= AddTarget;
    }

    private void AddTarget(Vector2 point)
    {
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, point);
        _lineRenderer.positionCount += 1;
        DefineLastPosition();
    }

    private void DefineLastPosition()
    {
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, _move.transform.position);
    }
}
