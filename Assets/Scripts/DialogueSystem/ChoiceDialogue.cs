using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using DialogueHelpers;

public class ChoiceDialogue : PopDialogue {
    //public enum ExitConditions
    //{
    //    EXPLORE_ALL,
    //    EXIT_BUTTON,
    //    ANSWER_QUESTION,
    //}

    public List<Text> clickablePages;
    //public ExitConditions exitCondition = ExitConditions.EXIT_BUTTON;
    //public GameObject exitObject;

    public override void Begin()
    {
        hasStarted = true;

        //if (exitCondition == ExitConditions.EXIT_BUTTON)
        //    exitObject.SetActive(true);
        //else
        //    exitObject.SetActive(false);

        if (linkNarrative)
            SyncByInspector();
        transform.GetChild(0).gameObject.SetActive(true);
        
        OnDialogue_Enter();
    }

    public override void SyncByInspector()
    {
        if (displayPages != null && clickablePages != null)
        {
            for (int i = 0; i < displayPages.pages.Count && i < clickablePages.Count; i++)
            {
                clickablePages[i].text = displayPages.pages[i].text;
            }
        }
    }

    //Expose the exit event here, to have some way of closing the choice dialogue
    public void EarlyExit()
    {
        //Debug.Log(UnityEngine.StackTraceUtility.ExtractStackTrace());
        OnDialogue_Exit();
    }
}
