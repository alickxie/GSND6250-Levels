using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class MotionPathPoint
{
public Vector3 position;
    public Quaternion rotation;
    public float speed; // 用于位置移动的速度
    public float rotationSpeed = 30f; // 每秒旋转度数，默认值为360
}

[CreateAssetMenu(fileName = "MotionPath", menuName = "Motion Path/New Motion Path", order = 1)]
public class MotionPathData : ScriptableObject
{
    public List<MotionPathPoint> points = new List<MotionPathPoint>();
}

