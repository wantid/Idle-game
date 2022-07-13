using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public static float[] NewLevel(int currentLevel, float multiplier)
    {
        float[] tmp = new float[2]; // [0] - price; [1] - income.

        tmp[0] = multiplier * Mathf.Pow(1.2f, currentLevel);
        tmp[1] = multiplier * currentLevel;

        return tmp;
    }
    public static float[] ObjectUpgrade(int currentLevel, float price)
    {
        float[] tmp = new float[2]; // [0] - price; [1] - income.

        tmp[0] = price + currentLevel * Mathf.Pow(1.2f, currentLevel);
        tmp[1] = price * Mathf.Pow(1.1f, currentLevel);

        return tmp;
    }
}
