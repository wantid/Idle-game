using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float Multiplier;
    private int CurrentLevel;

    public TextMesh textMesh;

    [HideInInspector] public float Income { get { return 1 + Multiplier * CurrentLevel; } }
    private float Price { get { return Multiplier * Mathf.Pow(1.2f, CurrentLevel); } }

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
        if (balance >= Price)
        {
            CurrentLevel++;
            TextUpdate();
        }

        return balance - Price;
    }
}
