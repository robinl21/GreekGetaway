using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndController : MonoBehaviour
{

    private string questName;
    // Start is called before the first frame update
    void Start()
    {
        questName = "Escape the frat!";
    }

    // Update is called once per frame
    void Update()
    {
        if (PhoneTaskController.phoneTask.allDone && JacketTaskController.jacketTask.allDone) {
            // create button/quest if not already made: add to all 3!
            if (!QuestScript.questScript.QuestSet.Contains(questName)) {
                QuestScript.questScript.allQuests.Add(questName);
                QuestScript.questScript.allStatus.Add("Leave TOGETHER with your friend at the ground floor");
                QuestScript.questScript.QuestSet.Add(questName);
            }    
        }
    }
}
