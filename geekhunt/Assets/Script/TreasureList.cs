using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureList : MonoBehaviour
{
    private int size = 9;
    public string[] title = new string[9]
    {
        "Mr. Hiroyuki",
        "2ch",
        "Bulletin board",
        "SE",
        "Programer",
        "Program",
        "OpenSource",
        "Full stack engineer",
        "Unity"

    };
    public string[] detail = new string[9]
    {
        "The person who made 2ch. He doesn't know about maps.",
        "Anonymous bulletin board on the net. It's not good to play on 2 channels of TV.",
        "A board for communicating information. Various people use it for their own purposes.",
        "Persons engaged in information system related work",
        "A person who creates a computer program",
        "Instructions for the computer are written. A bridge between people and computers.",
        "Source code / software that anyone can use. The legacy of our ancestors.",
        "A strong person.",
        "One of the frameworks often used when creating 3D games. Also active in making 2D games."
    };

    public int Size { get => size; set => size = value; }

    private GameObject Contents;
    private GameObject List_con;

    void Start()
    {
        Contents = this.transform.Find("Contents").gameObject;
        List_con = this.transform.Find("Scroll View").gameObject;
    }


    public void GetTreasure(int index)
    {
        if (GameManager.instance.isHave[index] == false)
        {
            GameManager.instance.isHave[index] = true;
            //Debug.Log(string.Format("{0}: is discover = {1}", title[index], isHave[index]));
            List_con.GetComponent<Chisiki_list_controller>().UpdateButton(index);
            //Contents.GetComponent<EditContesnts>().SetContents(title[index], detail[index]);
            //Contents.SetActive(true);
            //return true;
        }
        else
        {
            Debug.Log("This Treasure is already gotton.");
            //return false;
        }
    }


    //public string[] Title { get => title; set => title = value; }
    //public string[] Content { get => content; set => content = value; }
}
