using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [ContextMenu("SaveData")]
    public void SaveData()
    {
        PlayerPrefs.SetInt("PlayerLVL", GameManager.instance.Player.CurrentLevel);

        Transform parent = GameManager.instance.ObjectsParent;
        int objectsData;

        for (int i = 0; i < parent.childCount; i++)
        {
           // PlayerPrefs.SetInt($"Object{i}LVL", parent);
        }

        PlayerPrefs.Save();
    }
}
