using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyBoard : Board
{
    public GameObject button;
    public Text price;
    public GameObject[] initalBoards;
    public GameObject[] replacementBoards;
    public override void BoardStart()
    {
        base.BoardStart();
        for (int i = 0; i < replacementBoards.Length; i++)
            replacementBoards[i].SetActive(false);
        for (int c = 0; c < initalBoards.Length; c++)
            initalBoards[c].SetActive(true);
    }
    public override void BoardUpdate()
    {
        base.BoardUpdate();
    }
    public void Buy()
    {
        print("Вы приобрели ничто за " + price.text + " золотых стокоратных монет! ПОЗДРАВЛЯЮ");
        for (int i = 0; i < replacementBoards.Length; i++)
            replacementBoards[i].SetActive(true);
        for (int c = 0; c < initalBoards.Length; c++)
            initalBoards[c].SetActive(false);    
    }
}
