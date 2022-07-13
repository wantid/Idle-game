using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int CurrentLevel;
    private float Multiplier;

    public float Income;

    public float NewLevel(float balance)
    {
        float[] tmp = new float[2]; // [0] - price; [1] - income.

        tmp[0] = Multiplier * Mathf.Pow(1.2f, CurrentLevel);
        tmp[1] = Multiplier * CurrentLevel;

        if (balance > tmp[0])
        {
            Income = tmp[1];
            CurrentLevel++;
        }

        return balance - tmp[0];
    }
}
