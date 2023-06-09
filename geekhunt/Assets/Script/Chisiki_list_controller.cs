﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chisiki_list_controller : MonoBehaviour
{
    TreasureList tlist = new TreasureList();
    public static Chisiki_list_controller chisiki_List_Controller; 
    public GameObject button;
    private GameObject Contents;
    private GameObject Content;
    private GameObject[] Buttons;
    private int cnt;

    // Start is called before the first frame update
    void Start()
    {
        int size = tlist.Size;
        Buttons = new GameObject[size];
        var button_parent = this.transform.Find("Viewport/Content");
        for (int i = 0; i < size; i++)
        {
            //var chisiki = Instantiate(button, button_parent);
            //chisiki.GetComponent<Button>().SetNumber(i);
            //Debug.Log(string.Format("{0}: seted",i));
            Buttons[i] = Instantiate(button, button_parent);
            Buttons[i].GetComponent<Button>().SetNumber(i);

        }
        Contents = GameObject.Find("Contents");
        //Contents.SetActive(false);

        Content = GameObject.Find("Content");
        float bottom = -15 * (size);
        Content.GetComponent<RectTransform>().offsetMin = new Vector2(0f, bottom);
        //content.setActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateButton(int index)
    {
        //var b_script = 
        while(true)
        {
            cnt = Random.Range(0, GameManager.instance.isHave.Length);
            Debug.Log("GetTresure");
            if (GameManager.instance.treNum.Contains(cnt) == true && GameManager.instance.treNum.Count != 9)
            {
                Debug.Log(cnt);
                continue;
            }

            GameManager.instance.treNum.Add(cnt);
            break;
        }
        if (!GameManager.instance.isHave[cnt])
        {
            Buttons[cnt].GetComponent<Button>().GetTreasure_received();
            GameManager.instance.attack += 0.2f;
            GameManager.instance.cnt++;
        }
        //b_script.SetNumber(index);
        //b_script.onClick();
    }
}