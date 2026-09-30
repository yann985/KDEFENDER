using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] public Transform[] waypoints;

    public Transform[] Waypoints => waypoints;
}
