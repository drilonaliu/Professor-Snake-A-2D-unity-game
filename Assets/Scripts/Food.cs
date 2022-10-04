using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class Food : MonoBehaviour
{
    public TextMeshPro tmp;
    public FoodDelegate foodDelegate;
    public int apple_text;
    public float x_min, x_max, y_min, y_max; //range 
    private bool correct;

    void Start()
    {
        RandomPosition();
    }

    public void RandomPosition()
    {
        float x = Random.Range(x_min, x_max);
        float y = Random.Range(y_min, y_max);
        this.transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y));
    }

    public void setText(string text)
    {
        tmp.text = text;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        this.foodDelegate.collisionHappened(this);
    }

    public bool isCorrect()
    {
        return correct;
    }

    public void setCorrect(bool val)
    {
        correct = val;
    }

}
