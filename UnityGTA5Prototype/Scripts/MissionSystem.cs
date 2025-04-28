using UnityEngine;

public class MissionSystem : MonoBehaviour
{
    public enum MissionType { Pickup, Delivery, EnemyConfrontation }

    public MissionType currentMission;
    public Transform missionTarget;
    public bool missionActive = false;

    void Update()
    {
        if (missionActive)
        {
            float distance = Vector3.Distance(transform.position, missionTarget.position);
            if (distance < 3f)
            {
                CompleteMission();
            }
        }
    }

    public void StartMission(MissionType missionType, Transform target)
    {
        currentMission = missionType;
        missionTarget = target;
        missionActive = true;
        Debug.Log("Mission started: " + missionType.ToString());
    }

    void CompleteMission()
    {
        missionActive = false;
        Debug.Log("Mission completed: " + currentMission.ToString());
        // Add rewards or next mission logic here
    }
}
