using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Camera MainCamera;
    public Text BalanceText;
    public Transform ObjectsParent;
    public PlayerStats Player;

    [HideInInspector] public static GameManager instance;

    private float Balance;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        TouchHandler();
        BalanceTextUpdate();
    }
    public void BalanceIncrease()
    {
        float chg = 1;

        chg += Player.Income;

        foreach (Transform child in ObjectsParent)
            chg += child.GetComponent<ObjectStats>().Income;

        Debug.Log($"Income: {chg}");
        Balance += chg;
    }
    private void BalanceTextUpdate()
    {
        BalanceText.text = $"{Balance}$";
    }
    private void TouchHandler()
    {
        if (Input.GetMouseButtonUp(0))
        {

            RaycastHit hit;
            float chg = -1;

            if (Physics.Raycast(MainCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                switch (hit.collider.tag)
                {
                    case "Player":
                        chg = hit.collider.GetComponent<PlayerStats>().NewLevel(Balance);
                        break;
                    case "Object":
                        chg = hit.collider.GetComponent<ObjectStats>().ObjectUpgrade(Balance);
                        break;
                    default: return;
                }
            }

            if (chg >= 0) Balance = chg;
        }
    }
}
