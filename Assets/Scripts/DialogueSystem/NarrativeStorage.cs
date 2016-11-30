using UnityEngine;
using System.Collections;
using DialogueHelpers;
using System.Collections.Generic;


public class NarrativeStorage : MonoBehaviour {

    public List<StoryBook> allNarratives;

	// Use this for initialization
	void Start () {
        Initialize();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Initialize()
    {
        //Debug.Log("Start narrative");
        allNarratives = new List<StoryBook>();
        BuildNarratives();
    }

    void BuildNarratives()
    {
        StoryBook nextBook = new StoryBook("Test Room");
        {
            //All objects in a room get separate chapters
            //if an object can have more than 1 type of conversation in this room, it gets multiple chapters on separate dialogues
            StoryChapter nextChapter = NewChapter(1); //dialogue ID is passed in here
            {
                //Define all the pages this chapter (dialogue) will flip through along with its read time
                nextChapter.pages.Add(NewPage("Dialogue 1 Page 1 of new narrative, 2 seconds", 2.0f));
                nextChapter.pages.Add(NewPage("Dialogue 1 Page 2 of new narrative, 1 seconds", 1.0f));
            }
            //add the chapter to the book
            nextBook.chapters.Add(nextChapter);

            nextChapter = NewChapter(2);
            {
                //Define all the pages this chapter (dialogue) will flip through along with its read time
                nextChapter.pages.Add(NewPage("Dialogue 2 Page 1 of new narrative, 1 seconds", 1.0f));
                nextChapter.pages.Add(NewPage("Dialogue 2 Page 2 of new narrative, 2 seconds", 2.0f));
                nextChapter.pages.Add(NewPage("Dialogue 2 Page 3 of new narrative, 1 seconds", 1.0f));
            }
            //add the chapter to the book
            nextBook.chapters.Add(nextChapter);
        }
        //add the book to the narrative
        allNarratives.Add(nextBook);
        BuildNarrative_OrphanageScene();
    }

    void BuildNarrative_OrphanageScene()
    {
        StoryBook nextBook = new StoryBook("Orphanage Scene");
        {
            //Snoring Cubie conversation
            {
                StoryChapter nextChapter = NewChapter(100); //Snoring Cubie
                {
                    nextChapter.pages.Add(NewPage("zzzzzZZZZZ... ", 2.0f));
                    nextChapter.pages.Add(NewPage("Stay away... no... salad", 2.0f));
					nextChapter.pages.Add(NewPage("Can't help it... allergic...", 2.0f));
                }
                nextBook.chapters.Add(nextChapter);

				nextChapter = NewChapter(101); //Boxii response
                {
                    nextChapter.pages.Add(NewPage("He must be dreaming about dinner earlier.", 3.0f));
					//nextChapter.pages.Add(NewPage("Maybe not.", 2.0f));
                }
                nextBook.chapters.Add(nextChapter);
            }

			//Crying Cubie conversation
			{
				StoryChapter nextChapter = NewChapter(200); //Crying Cubie
				{
					nextChapter.pages.Add(NewPage("Boo hoo. Boo hoo hoo.", 3.0f));
				}
				nextBook.chapters.Add(nextChapter);

				nextChapter = NewChapter(201); //Boxii response
				{
					nextChapter.pages.Add(NewPage("What's the matter?", 3.0f));
				}
				nextBook.chapters.Add(nextChapter);
			}
        }
        //add the book to the narrative
        allNarratives.Add(nextBook);
    }

    StoryChapter NewChapter(int dialogueID)
    {
        return new StoryChapter(dialogueID);
    }

    StoryPage NewPage(string text, float readTime)
    {
        return new StoryPage(text, readTime);
    }

    public StoryChapter FindChapter(int prDialogueID)
    {
        if (allNarratives != null)
        {
            //Debug.Log("narrative not null");
            for (int i = 0; i < allNarratives.Count; i++)
            {
                //Debug.Log("nextBook");
                StoryBook nextBook = allNarratives[i];
                if (nextBook != null)
                {
                    //Debug.Log("nextBook not null");
                    for (int x = 0; x < nextBook.chapters.Count; x++)
                    {
                       // Debug.Log("chapters");
                        if (prDialogueID == nextBook.chapters[x].dialogueID)
                        {
                           // Debug.Log("chapter found: " + prDialogueID.ToString());
                            return nextBook.chapters[x];
                        }
                    }
                }
            }
        }

        return null;
    }
}
