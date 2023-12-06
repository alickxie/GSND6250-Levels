using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class MotionPathPoint
{
    public Vector3 position;
    public Quaternion rotation;
    public float speed;
}

[CreateAssetMenu(fileName = "MotionPath", menuName = "Motion Path/New Motion Path", order = 1)]
public class MotionPathData : ScriptableObject
{
    public List<MotionPathPoint> points = new List<MotionPathPoint>();
}

