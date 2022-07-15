using System;
using UnityEngine;


public class SaveManager : MonoBehaviour
{
    [ContextMenu("SaveData")]
    public void SaveData()
    {
        Transform parent = GameManager.instance.ObjectsParent;

        PlayerPrefs.SetFloat("Balance", GameManager.instance.Balance);
        PlayerPrefs.SetInt("PlayerLVL", GameManager.instance.Player.CurrentLevel);

        for (int i = 0; i < parent.childCount; i++)
           PlayerPrefs.SetInt($"Object{i}LVL", parent.GetChild(i).GetComponent<ObjectStats>().CurrentLevel);

        PlayerPrefs.SetString("Date", DateTime.Now.ToString());

        PlayerPrefs.Save();
    }

    [ContextMenu("LoadData")]
    public void LoadData()
    {
        Transform parent = GameManager.instance.ObjectsParent;
        DateTime lastDate;
        int difference;

        GameManager.instance.Balance = PlayerPrefs.GetFloat("Balance");
        GameManager.instance.Player.ChangeLevel(PlayerPrefs.GetInt("PlayerLVL"));

        for (int i = 0; i < parent.childCount; i++)
            parent.GetChild(i).GetComponent<ObjectStats>().ChangeLevel(PlayerPrefs.GetInt($"Object{i}LVL"));

        DateTime.TryParse(PlayerPrefs.GetString("Date"), out lastDate);
        TimeSpan span = DateTime.Now.Subtract(lastDate);
        difference = (int)span.TotalSeconds;
        GameManager.instance.Balance += difference * GameManager.instance.CountIncome();
    }

    [ContextMenu("RemoveData")]
    public void RemoveData()
    {
        PlayerPrefs.DeleteAll();
    }
}
