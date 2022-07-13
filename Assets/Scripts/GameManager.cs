using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float Balance;

    public Camera MainCamera;
    public Text BalanceText;

    private void Update()
    {
        TouchHandler();
        BalanceTextUpdate();
    }
    private void BalanceTextUpdate()
    {
        BalanceText.text = $"{Balance}$";
    }
    private void TouchHandler()
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
