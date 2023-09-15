using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public List<Transform> points;
    private void Start()
    {
        LoadPoint();
    }
    private void LoadPoint()
    {
        if (points.Count > 0) return;
        foreach(Transform point in transform)
        {
            points.Add(point);
        }
    }
    public Transform RandomPoint()
    {
        return points[Random.Range(0, points.Count)];
    }
}
