using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Question : MonoBehaviour
{

    public TextMeshPro q;
    public int option_count;
    private int num1;
    private int num2;
    private int correct_answer;
    private List<Answer> options;

    public void makeQuestion()
    {
        this.options = new List<Answer>();

        num1 = Random.Range(1, 10);
        num2 = Random.Range(1, 10);
        correct_answer = num1 * num2;

        options.Add(new Answer(correct_answer, true));
        for (int i = 1; i < option_count; i++)
        {
            int value = generateFalseOption();
            options.Add(new Answer(value, false));
        }
        q.text = num1 + "•" + num2;
    }

    private int generateFalseOption()
    {
        int option = Random.Range(1, 10) * Random.Range(1, 10);
        if (option == correct_answer)
        {
            return generateFalseOption();
        }
        return option;
    }

    public List<Answer> getOptions()
    {
        return options;
    }

    public int getAnswer()
    {
        return correct_answer;
    }
}
