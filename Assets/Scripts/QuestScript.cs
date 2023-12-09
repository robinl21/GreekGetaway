using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScript : MonoBehaviour
{

    public static QuestScript questScript;



    // make sure to update 3
    // check for in questset before adding
    public List<string> allQuests;

    public List<string> allStatus;

    public HashSet<string> QuestSet;


    private void Awake()
    {
        QuestSet = new HashSet<string>();

        allStatus = new List<string>();

        allQuests = new List<string>();

        // handle initializing which quests we want
        questScript = this;
        // Debug.Log("ADD");
        allQuests.Add("Find Your Jacket!");
        allStatus.Add("Try talking to other people at the party!");
        QuestSet.Add("Find Your Jacket!");

        allQuests.Add("Find Your Phone!");
        allStatus.Add("Try talking to other people at the party!");
        QuestSet.Add("Find Your Jacket!");
        // allQuests.Add("Get to the second floor");
        // questStatus.Add("Get to the second floor", "There's a brother stopping you...");
        // allQuests.Add("Find your bong");
        // questStatus.Add("Find your bong", "That guy with glasses looks fishy...");

    }

    public void UpdateStatus(string questName, string newStatus) {
        int i = allQuests.IndexOf(questName);
        allStatus[i] = newStatus;
    }    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
