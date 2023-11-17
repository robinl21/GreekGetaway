using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScript : MonoBehaviour
{

    public static QuestScript questScript;


    public List<string> allQuests;
    public IDictionary<string, string> questStatus = new Dictionary<string, string>();

    private void Awake()
    {
        questScript = this;
        Debug.Log("ADD");
        allQuests.Add("Find Your Jacket!");
        questStatus.Add("Find Your Jacket!", "Try talking to other people at the party");
        allQuests.Add("Find Your Phone!");
        questStatus.Add("Find Your Phone!", "Try talking to other people at the party");
        allQuests.Add("Get to the second floor");
        questStatus.Add("Get to the second floor", "There's a brother stopping you...");

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
