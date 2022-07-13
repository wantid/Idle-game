using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float Multiplier;
    private int CurrentLevel;

    public TextMesh textMesh;

    private float Price { get { return 2 * Multiplier * Mathf.Pow(1.25f, CurrentLevel); } }
    [HideInInspector] public float Income { get { return Multiplier + Multiplier * CurrentLevel; } }

    private void Start()
    {
        TextUpdate();
    }
    private void TextUpdate()
    {
        textMesh.text = $"Lvl.{CurrentLevel}\nPrice {Price}\nIncome {Income}";
    }
    public float NewLevel(float balance)
    {
        float chg = balance - Price;

        if (chg >= 0)
        {
            CurrentLevel++;
            TextUpdate();
        }

        return chg;
    }
}
