using UnityEngine;

public class ObjectStats : MonoBehaviour
{
    public float Price;
    [HideInInspector] public float Income;

    private int CurrentLevel;

    public float ObjectUpgrade(float balance)
    {
        float[] tmp = new float[2]; // [0] - price; [1] - income.

        tmp[0] = Price + CurrentLevel * Mathf.Pow(1.2f, CurrentLevel);
        tmp[1] = Price * Mathf.Pow(1.1f, CurrentLevel);

        if (balance > tmp[0])
        {
            Income = tmp[1];
            CurrentLevel++;
        }

        return balance - tmp[0];
    }
}
