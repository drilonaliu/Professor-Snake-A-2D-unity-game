using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class GameController : MonoBehaviour, FoodDelegate
{
    public Player player;
    public Food food;
    public Question question;
    public Score score;
    public Timer timer;
    public BoxCollider2D grid_area;
    public HealthBar health_bar;
    public GameObject retry_button;
    public List<Food> all_apples;
    private int num_food = 3;
    private float countdown = 10;
    private bool isGameOver = false;

    public void Start()
    {
        question.makeQuestion();
        GenerateApples();
        retry_button.SetActive(false);
    }

    void FixedUpdate()
    {
        if (!isGameOver)
        {
            if (!timer.haveTime())
            {
                timer.startTime();
                timer.setTimer(countdown);
                health_bar.removeHeart();
                checkGameOver();
            }
        }
    }


    void FoodDelegate.collisionHappened(Food f)
    {
        timer.setTimer(countdown);
        if (f.isCorrect())
        {
            player.Grow();
            score.increase();
            timer.setTimer(timer.getCurrentTime() + 2);
        }
        else
        {
            player.Shrink();
            score.decrease();
            health_bar.removeHeart();
            timer.setTimer(timer.getCurrentTime() - 3);
        }

        checkGameOver();
    }


    void checkGameOver()
    {
        if (health_bar.lifeAmount() == 0)
        {
            isGameOver = true;
            endGame();
        }
        else
        {
            question.makeQuestion();
            updateApples(question.getOptions());
        }
    }


    public void endGame()
    {
        retry_button.SetActive(true);
        destroyAllApples();
        timer.stopTime();
    }


    public void resetGame()
    {
        health_bar.Start();
        score.reset();
        isGameOver = false;
        timer.startTime();
        timer.setTimer(countdown);
        player.destroyBody();
        this.Start();
    }

    public void destroyAllApples()
    {
        foreach (Food apple in all_apples)
        {
            Destroy(apple.transform.gameObject);
        }

    }

    public void updateApples(List<Answer> options)
    {
        for (int i = 0; i < all_apples.Count; i++)
        {
            Food apple = all_apples[i];
            Answer option = options[i];

            apple.RandomPosition();
            apple.setCorrect(option.is_correct);
            apple.setText(option.value + "");
        }
    }

    public void GenerateApples()
    {
        all_apples = new List<Food>(num_food);
        float x_min = grid_area.bounds.min.x;
        float x_max = grid_area.bounds.max.x;
        float y_min = grid_area.bounds.min.y;
        float y_max = grid_area.bounds.max.y;
        for (int i = 0; i < num_food; i++)
        {
            Food f = Instantiate(this.food);

            f.foodDelegate = this;

            f.x_min = x_min;
            f.x_max = x_max;
            f.y_min = y_min;
            f.y_max = y_max;

            all_apples.Add(f);
        }

        updateApples(question.getOptions());
    }
}