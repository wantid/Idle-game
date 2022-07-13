using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float Multiplier;
    [HideInInspector] public float Income;
    public TextMesh textMesh;

    private int CurrentLevel;

    public float NewLevel(float balance)
    {
        float[] tmp = new float[2]; // [0] - price; [1] - income.

        tmp[0] = Multiplier * Mathf.Pow(1.2f, CurrentLevel);
        tmp[1] = Multiplier * CurrentLevel;

        if (balance > tmp[0])
        {
            Income = tmp[1];
            CurrentLevel++;
            textMesh.text = $"{CurrentLevel}";
        }

        return balance - tmp[0];
    }
}
