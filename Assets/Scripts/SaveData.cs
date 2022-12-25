using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class SaveData : MonoBehaviour
{
    public Inventory inventory = new Inventory();

	private void Start ()
	{
        LoadFromJson();
	}
	private void FixedUpdate ()
    {
        if ((Time.time % 10) >= 9)
        {
            SaveToJson();
        }
    }
	public void SaveToJson() 
    {
        string inventoryData = JsonUtility.ToJson(inventory);
        string filePath = Application.persistentDataPath + "/SaveData.json";
        System.IO.File.WriteAllText(filePath, inventoryData);
    }

    public void LoadFromJson()
    {
		string filePath = Application.persistentDataPath + "/SaveData.json";
        string inventoryData = System.IO.File.ReadAllText(filePath);

        inventory = JsonUtility.FromJson<Inventory>(inventoryData);
	}
}

[System.Serializable]
public class Inventory
{
    public string Level;
    public Vector3 Position;
    public List<Items> items = new List<Items>();
}

[System.Serializable]
public class Items
{
    public string name;
    public string desc;
}