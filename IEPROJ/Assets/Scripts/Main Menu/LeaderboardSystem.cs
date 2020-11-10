using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardSystem : MonoBehaviour
{
    private Dictionary<string, int> player_Dictionary;
    private List<string> ranked_Player;
    private List<int> ranked_Score;
    private List<string> player_List;
    private GameObject ranking_List;

    private void Start()
    {
        this.ranking_List = this.transform.Find("Ranking").gameObject;
        this.player_Dictionary = new Dictionary<string, int>();
        this.ranked_Player = new List<string>();
        this.ranked_Score = new List<int>();
        this.player_List = new List<string>();

        this.getInfo();
    }

    void Update()
    {
        this.getInfo();
        this.updateRank();
        this.setRank();
        this.printList();
    }

    private void getInfo()
    {
        this.player_List.Clear();
        this.player_Dictionary.Clear();

        for(int i = 0; i <= ProfileSystem.listCount; i++)
        {
            this.player_List.Add(PlayerPrefs.GetString("User_List_" + i));
            this.player_Dictionary.Add(this.player_List[i], PlayerPrefs.GetInt(this.player_List[i] + "_Score"));
        }
    }

    private void updateRank()
    {
        for(int i = 0; i <= ProfileSystem.listCount; i++)
        {
            this.player_Dictionary[this.player_List[i]] = PlayerPrefs.GetInt(this.player_List[i] + "_Score");
        }
    }

    private void setRank()
    {
        var temp = from pair in this.player_Dictionary orderby pair.Value descending select pair;

        this.ranked_Player.Clear();
        this.ranked_Score.Clear();

        foreach (KeyValuePair<string, int> pair in temp)
        {
            this.ranked_Player.Add(pair.Key);
            this.ranked_Score.Add(pair.Value);
        }
    }

    private void printList()
    {
        for(int i = 0; i <= ProfileSystem.listCount; i++)
        {
            this.ranking_List.transform.Find(i + 1 + "_Name").GetComponent<Text>().text = "" + (i + 1) + ". " + this.ranked_Player[i];
            this.ranking_List.transform.Find(i + 1 + "_Score").GetComponent<Text>().text = "" + this.ranked_Score[i];
        }
    }
}
