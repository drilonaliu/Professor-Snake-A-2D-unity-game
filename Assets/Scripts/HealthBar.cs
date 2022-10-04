using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Transform heart_prefab;
    public List<Transform> heart_list;

    public void Start()
    {
        heart_list = new List<Transform>();
        for (int i = 0; i < 3; i++)
        {
            Transform go = Instantiate(this.heart_prefab);
            go.transform.parent = this.transform;
            go.transform.position = go.transform.position + new Vector3(30 * i, 0, 0);
            heart_list.Add(go);
        }
    }

    public void removeHeart()
    {
        Destroy(heart_list[heart_list.Count - 1].transform.gameObject);
        heart_list.RemoveAt(heart_list.Count - 1);
    }

    public int lifeAmount()
    {
        return heart_list.Count;
    }
}
