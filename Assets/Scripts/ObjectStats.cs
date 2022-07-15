using UnityEngine;

public class ObjectStats : MonoBehaviour
{
    public float initialPrice;
    public TextMesh textMesh;
    [HideInInspector] public int CurrentLevel;

    private float Price { get { return initialPrice + CurrentLevel * Mathf.Pow(1.2f, CurrentLevel); } }
    [HideInInspector] public float Income { get { return CurrentLevel * initialPrice * Mathf.Pow(1.1f, CurrentLevel); } }

    private void Start()
    {
        TextUpdate();
    }

    private void TextUpdate()
    {
        textMesh.text = $"Lvl.{CurrentLevel}\nPrice {Price}\nIncome {Income}";
    }

    public float ObjectUpgrade(float balance)
    {
        float chg = balance - Price;

        if (chg >= 0)
        {
            CurrentLevel++;
            TextUpdate();
        }

        return chg;
    }

    public void ChangeLevel(int newLevel)
    {
        CurrentLevel = newLevel;
        TextUpdate();
    }
}
