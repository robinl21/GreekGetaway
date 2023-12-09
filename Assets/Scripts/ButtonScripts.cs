using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ButtonScripts : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject buttonTemplate;

    public List<string> allQuests;

    public List<string> allStatus;

    public List<GameObject> activeButtons;
    void Start()
    {
        allQuests = QuestScript.questScript.allQuests;
        allStatus = QuestScript.questScript.allStatus;
        int questCount = QuestScript.questScript.allQuests.Count;

        for (int i = 0; i < questCount; i++) {
            GameObject btn = (GameObject)Instantiate(buttonTemplate); // create new entries dynamically
            GameObject btnText = btn.transform.GetChild(0).gameObject; // task
            btnText.GetComponent<TMP_Text>().text = allQuests[i];

            GameObject statusText = btn.transform.GetChild(1).gameObject; //status
            statusText.GetComponent<TMP_Text>().text = allStatus[i];

            btn.SetActive(true);
            btn.transform.SetParent(this.gameObject.transform); //makes button as a child

            activeButtons.Add(btn);
        }

    }

    // Update is called once per frame
    void Update()
    {
        int questCount = allQuests.Count;
        for (int i = 0; i < questCount; i++) {
            if (i < activeButtons.Count) {
                // check for updates
                GameObject button = activeButtons[i];
                GameObject statusText = button.transform.GetChild(1).gameObject;
                statusText.GetComponent<TMP_Text>().text = allStatus[i];
            }
             
            else {
                // construct new button
                GameObject btn = (GameObject)Instantiate(buttonTemplate); // create new entries dynamically
                GameObject btnText = btn.transform.GetChild(0).gameObject; // task
                btnText.GetComponent<TMP_Text>().text = allQuests[i];

                GameObject statusText = btn.transform.GetChild(1).gameObject; //status
                statusText.GetComponent<TMP_Text>().text = allStatus[i];

                btn.SetActive(true);
                btn.transform.SetParent(this.gameObject.transform); //makes button as a child
                Debug.Log("ADDED");
                activeButtons.Add(btn);  
            }
        }
    }


}
