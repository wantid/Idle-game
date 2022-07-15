using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Camera MainCamera;
    public Text BalanceText;

    public float Balance;

    [HideInInspector] public Transform ObjectsParent;
    [HideInInspector] public PlayerStats Player;
    [HideInInspector] public static GameManager instance;

    private SaveManager saveManager;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;

        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        ObjectsParent = GameObject.FindGameObjectWithTag("ParentObject").transform;

        saveManager = GetComponent<SaveManager>();
    }

    private void Start()
    {
        saveManager.LoadData();
    }

    private void Update()
    {
        TouchHandler();
        BalanceTextUpdate();
    }

    private void OnApplicationQuit()
    {
        saveManager.SaveData();
    }

    public float CountIncome()
    {
        float totalIncome = 0;

        foreach (Transform child in ObjectsParent)
            totalIncome += child.GetComponent<ObjectStats>().Income;

        totalIncome = Player.Income * (1 + totalIncome / ObjectsParent.childCount);

        return totalIncome;
    }

    public void BalanceIncrease()
    {
        float chg = CountIncome();
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
