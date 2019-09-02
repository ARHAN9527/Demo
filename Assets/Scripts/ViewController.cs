using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using GameControllerNamespace;

public class ViewController : MonoBehaviour
{    
    public Image[] column1, column2, column3, column4;
    public Sprite[] classes, prizes;
    
    private GameController gameController = new GameController();
    private delegate int[, ] GameDelegate();
    private bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateSlot(gameController.Init);
        ShowPrize();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            UpdateSlot(gameController.Run);
        }            
    }

    private void UpdateSlot(GameDelegate gameDelegate)
    {
        int[, ] array = gameDelegate();

        for (int i = 0; i < array.GetLength(1); i++)
        {
            column1[i].sprite = classes[array[0, i]];
            column2[i].sprite = classes[array[1, i]];
            column3[i].sprite = classes[array[2, i]];
        }
    }

    private void ShowPrize()
    {
        int[] result = gameController.Result();
        for (int i = 0; i < result.Length; i++)
        {
            column4[i].sprite = prizes[result[i]];
        }
    }

    public void Run()
    {
        isRunning = true;
    }

    public void Stop()
    {
        isRunning = false;
        ShowPrize();
    }

}
