using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ButtonScripts : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject buttonTemplate;

    public int btnCount;

    public List<string> allQuests;
    public IDictionary<string, string> questStatus;
    void Start()
    {
        allQuests = QuestScript.questScript.allQuests;
        questStatus = QuestScript.questScript.questStatus;
        btnCount = QuestScript.questScript.allQuests.Count;

        for (int i = 0; i < btnCount; i++) {
            GameObject btn = (GameObject)Instantiate(buttonTemplate); // create new entries dynamically
            GameObject btnText = btn.transform.GetChild(0).gameObject; // task
            btnText.GetComponent<TMP_Text>().text = allQuests[i];

            GameObject statusText = btn.transform.GetChild(1).gameObject; //status
            statusText.GetComponent<TMP_Text>().text = questStatus[allQuests[i]];

            btn.SetActive(true);
            btn.transform.SetParent(this.gameObject.transform); //makes button as a child
        }

    }

    // Update is called once per frame
    void Update()
    {
        // var container = this.gameObject.transform;
        // for (var i = 0; i < container.childCount; i++) {
        //     GameObject btn = container.GetChild(i).gameObject; 

        //     // Debug.Log(container.GetChild(i));
        // }
    }


}
