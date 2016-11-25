using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DialogueHelpers{
    //Most of these classes are just storage data classes for ease of use in dialogues and narrative

    public enum InteractType
    {
        ENTER,
        EXIT,
        DELAYED_ENTER,
        DELAYED_EXIT,
    }

    /**************************************************************
     * StoryPage -
     *      This class describes a set of narrative for a single piece of a conversation.
     *      readTime describes how long it takes to read this page 
     * ***********************************************************/
    [System.Serializable]
    public class StoryPage : System.Object
    {
        public string text;
        public float readTime;

        public StoryPage()
        {

        }

        public StoryPage(string prText, float prReadTime)
        {
            text = prText;
            readTime = prReadTime;
        }

        public StoryPage GetClone()
        {
            return new StoryPage(text, readTime);
        }
    }

    /**************************************************************
     * StoryChapter -
     *      This class describes a set of narrative for a specific object in a specific room for a specific part of a conversation. 
     *      This will hold a single instance of dialogue narrative.
     *      If you want another set of narrative for a specific object, simply make another chapter for it as it belongs to a different dialogue. 
     *      Desired use should be to show a sequential list of narrative pages. Allowing time for the player to read a page before advancing to the next page
     * ***********************************************************/
    [System.Serializable]
    public class StoryChapter : System.Object
    {
        public bool hasBeenRead = false; //this informs us if this chapter has been read by the player already
        public int currentPage = 0; //Track the current page in use
        public List<StoryPage> pages;
        public int dialogueID = -1; //id to determine what dialogue this text should belong to

        public StoryChapter()
        {
            if(pages == null)
                pages = new List<StoryPage>();
        }

        public StoryChapter(int dialogueID)
        {
            if (pages == null)
                pages = new List<StoryPage>();
            this.dialogueID = dialogueID;
        }

        //sets pages to point at prPages as well, if you want a clone, pass a clone in
        public StoryChapter(List<StoryPage> prPages, int prDialogueID, bool prHasBeenRead, int prCurrentPage)
        {
            pages = prPages;
            dialogueID = prDialogueID;
            hasBeenRead = prHasBeenRead;
            currentPage = prCurrentPage;
        }

        public StoryPage AdvancePages()
        {
            currentPage++;
            if (currentPage < pages.Count)
                return pages[currentPage];
            return null;
        }

        public StoryPage GetCurrentPage()
        {
            if (currentPage < pages.Count)
                return pages[currentPage];
            return null;
        }

        public StoryChapter GetClone()
        {
            return new StoryChapter(GetPagesClone(), dialogueID, hasBeenRead, currentPage);
        }

        public List<StoryPage> GetPagesClone()
        {
            List<StoryPage> pageList = new List<StoryPage>();
            for(int i = 0; i < pages.Count; i++)
            {
                pageList.Add(new StoryPage(pages[i].text, pages[i].readTime));
            }
            return pageList;
        }

        public float GetChapterReadTime()
        {
            float totalTime = 0.0f;
            for (int i = 0; i < pages.Count; i++)
            {
                totalTime += pages[i].readTime;
            }
            return totalTime;
        }
    }

    /**************************************************************
     * StoryBook -
     *      This class describes a set of narrative for a specific room. All conversations / pop ups in a room will belong to a chapter within the book.
     * ***********************************************************/
    [System.Serializable]
    public class StoryBook : System.Object
    {
        public string text; //describe this book
        public List<StoryChapter> chapters;
        public StoryBook()
        {
            if (chapters == null)
                chapters = new List<StoryChapter>();
        }
        public StoryBook(string text)
        {
            this.text = text;
            chapters = new List<StoryChapter>();
        }
    }


    [System.Serializable]
    public class DialogueInteract : System.Object
    {
        [Tooltip("PopDialogue script to watch for the event chosen through watchInteract.")]
        public PopDialogue watchDialogue;
        [Tooltip("Base this dialogue appearing on chosen event attached to the script in watchDialogue.")]
        public InteractType watchInteract = InteractType.EXIT;
        [Tooltip("Amount of time to wait after the watched event occurs. Used with Delayed_Enter and Delayed_Exit.")]
        public float delayedInteract = 0.0f;
    }
}
