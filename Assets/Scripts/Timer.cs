using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("Timer settings")]
    public int reloadTime;
    public int currentTime; // Can be set from inspector as a start time

    private void FixedUpdate()
    {
        if (currentTime < reloadTime)
            currentTime++;
        else
        {
            currentTime = 0;
            GameManager.instance.BalanceIncrease();
        }
    }
}
