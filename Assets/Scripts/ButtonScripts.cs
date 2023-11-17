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
            GameObject btn = (GameObject)Instantiate(buttonTemplate);
            GameObject btnText = btn.transform.GetChild(0).gameObject;
            btnText.GetComponent<TMP_Text>().text = allQuests[i];
            btn.SetActive(true);
            btn.transform.SetParent(this.gameObject.transform); //makes button as a child
        }

    }

    // Update is called once per frame
    void Update()
    {
        var container = this.gameObject.transform;
        for (var i = 0; i < container.childCount; i++) {
            // Debug.Log(container.GetChild(i));
        }
    }
}
