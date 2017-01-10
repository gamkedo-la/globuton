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

        BuildNarrative_OrphanageScene_Examples();
    }

    void BuildNarrative_OrphanageScene_Examples()
    {
        //Example narrative for SCC choice conversation
        StoryBook nextBook = new StoryBook("Orphanage Scene_Examples");
        {
            //Softly Crying Cubie conversation w/ choice
            {
                StoryChapter nextChapter = NewChapter(1005); //Softly Crying Cubie
                {
                    nextChapter.pages.Add(NewPage("Boo hoo. Boo hoo hoo.", 3.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(1006); //Boxii response
                {
                    nextChapter.pages.Add(NewPage("What's the matter?", 2.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(1007); //Softly crying cubie response to ^
                {
                    nextChapter.pages.Add(NewPage("Oh, don't mind me, Boxii. I just can't sleep.", 3.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(1008); //Boxii choice start text
                {
                    nextChapter.pages.Add(NewPage("Is it because you had that dream where you were...", 3.5f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(1009); //Boxii choices text
                {
                    nextChapter.pages.Add(NewPage("...trying in vain to escape the clutches of horrible, grotesque monsters?", 3.5f)); //1
                    nextChapter.pages.Add(NewPage("...falling and falling until the ground opened up and swallowed you whole?", 3.5f));//2
                    nextChapter.pages.Add(NewPage("...walking around all day with a piece of food stuck between your teeth?", 3.5f));  //3
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(1016); //Boxii choices text1
                {
                    nextChapter.pages.Add(NewPage("Trying in vain to escape the clutches of horrible, grotesque monsters?", 3.5f)); //1
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(1017); //Boxii choices text2
                {
                    nextChapter.pages.Add(NewPage("Falling and falling until the ground opened up and swallowed you whole?", 3.5f));//2
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(1018); //Boxii choices text3
                {
                    nextChapter.pages.Add(NewPage("Walking around all day with a piece of food stuck between your teeth?", 3.5f));  //3
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(1010); //SCC choice responses 1
                {
                    nextChapter.pages.Add(NewPage("No.", 1.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(1011); //SCC choice responses 2
                {
                    nextChapter.pages.Add(NewPage("No.", 1.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(1012); //SCC choice responses 3
                {
                    nextChapter.pages.Add(NewPage("No.", 1.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(1014); //SCC exhausted responses
                {
                    nextChapter.pages.Add(NewPage("Actually, I'm just sad that you haven't returned with our food.", 3.0f));
                    nextChapter.pages.Add(NewPage("Now, if you don't mind, I'm going to cry myself to sleep.", 3.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(1015); //Boxii exhausted response to ^
                {
                    nextChapter.pages.Add(NewPage("Don't worry. My nightly runs to the dump never fail!", 2.5f));
                }
                nextBook.chapters.Add(nextChapter);

            }

            //Snoring Cubie conversation w/ choice
            {
                StoryChapter nextChapter = NewChapter(2001); //Snoring Cubie
                {
                    nextChapter.pages.Add(NewPage("ZZZ-Zzzz-ZZzzz-hngGGggh-Mmppfft-zZZzzzZZ...", 3.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(2002); //Boxii response
                {
                    nextChapter.pages.Add(NewPage("Uh, I’m going to need you to repeat that.", 3.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(2003); //Snoring Cubie response to ^
                {
                    nextChapter.pages.Add(NewPage("ZZZ-Zzzz-had-zZZzz-enough-zZZzzzZZ...", 3.0f));
                }
                nextBook.chapters.Add(nextChapter);
                                
                nextChapter = NewChapter(2004); //Boxii choices text
                {
                    nextChapter.pages.Add(NewPage("Did you sneak some of the Sphere's food again?", 4.0f)); //1
                    nextChapter.pages.Add(NewPage("Is someone picking on you again?", 4.0f));//2
                    nextChapter.pages.Add(NewPage("I've had about enough of the rancid air coming from the food chute.", 4.5f));  //3
                    nextChapter.pages.Add(NewPage("You're not already tired of my questions, are you?", 4.0f));  //4
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(2005); //Boxii choices text1
                {
                    nextChapter.pages.Add(NewPage("Did you sneak some of the Sphere's food again?", 3.5f)); //1
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(2006); //Boxii choices text2
                {
                    nextChapter.pages.Add(NewPage("Is someone picking on you again?", 3.5f));//2
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(2007); //Boxii choices text3
                {
                    nextChapter.pages.Add(NewPage("I've had about enough of the rancid air coming from the food chute.", 4.5f));  //3
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(2008); //Boxii choices text4
                {
                    nextChapter.pages.Add(NewPage("You're not already tired of my questions, are you?", 3.5f));  //3
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(2009); //Snoring Cubie choice responses 1
                {
                    nextChapter.pages.Add(NewPage("ZZZ-itchy-un-zZZz-controllable-zZZzzzZZ...", 3.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(2010); //Snoring Cubie choice responses 2
                {
                    nextChapter.pages.Add(NewPage("ZZZ-Zzzz-ZZzzz-time-out-zZZzzzZZ...", 3.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(2011); //Snoring Cubie choice responses 3
                {
                    nextChapter.pages.Add(NewPage("ZZZ-Zzzz-trroOOvff-Mmppfft-ZZzzz-zZZzzzZZ...", 3.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(2012); //Snoring Cubie choice responses 4
                {
                    nextChapter.pages.Add(NewPage("ZZZ-Zzzz-ZZzzz-nngGGggh-SSHhnno-zZZzzzZZ...", 3.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(2013); //Boxii replies to Snoring Cubie 1
                {
                    nextChapter.pages.Add(NewPage("I tried to warn you.", 2.0f));
                    nextChapter.pages.Add(NewPage("You never know what they may add to the food here.", 3.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(2014); //Boxii replies to Snoring Cubie 2
                {
                    nextChapter.pages.Add(NewPage("Those Galena brothers are never up to any good.", 4.0f));
                    nextChapter.pages.Add(NewPage("I'll bet one of them got a timeout.", 3.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(2015); //Boxii replies to Snoring Cubie 3
                {
                    nextChapter.pages.Add(NewPage("My nose would've fallen off by now if I had to sleep here.", 4.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(2016); //Boxii replies to Snoring Cubie 4
                {
                    nextChapter.pages.Add(NewPage("Whoa, take it easy.", 2.5f));
                    nextChapter.pages.Add(NewPage("I'm just rying to get to the bottom of this.", 3.5f));
                }
                nextBook.chapters.Add(nextChapter);
                             
            }

            //Softly Crying Cubie conversation w/ choice example 2
            {
                StoryChapter nextChapter = NewChapter(1101); //Softly Crying Cubie
                {
                    nextChapter.pages.Add(NewPage("Boo hoo. Boo hoo hoo.", 3.0f));
                    nextChapter.pages.Add(NewPage("", 2.0f));
                    nextChapter.pages.Add(NewPage("Oh, don't mind me. I just can't sleep.", 3.0f));
                    nextChapter.pages.Add(NewPage("", 3.5f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(1102); //Boxii response
                {
                    nextChapter.pages.Add(NewPage("", 3.0f));
                    nextChapter.pages.Add(NewPage("What's the matter?", 2.0f));
                    nextChapter.pages.Add(NewPage("", 3.0f));
                    nextChapter.pages.Add(NewPage("Is it because you had that dream where you were...", 3.5f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(1103); //Boxii choices text
                {
                    nextChapter.pages.Add(NewPage("...trying in vain to escape the clutches of horrible, grotesque monsters?", 3.5f)); //1
                    nextChapter.pages.Add(NewPage("...falling and falling until the ground opened up and swallowed you whole?", 3.5f));//2
                    nextChapter.pages.Add(NewPage("...walking around all day with a piece of food stuck between your teeth?", 3.5f));  //3
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(1104); //Boxii choices text1
                {
                    nextChapter.pages.Add(NewPage("...trying in vain to escape the clutches of horrible, grotesque monsters?", 3.5f)); //1
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(1105); //Boxii choices text2
                {
                    nextChapter.pages.Add(NewPage("...falling and falling until the ground opened up and swallowed you whole?", 3.5f));//2
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(1106); //Boxii choices text3
                {
                    nextChapter.pages.Add(NewPage("...walking around all day with a piece of food stuck between your teeth?", 3.5f));  //3
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(1107); //SCC choice responses 1
                {
                    nextChapter.pages.Add(NewPage("No.", 1.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(1108); //SCC exhausted responses
                {
                    nextChapter.pages.Add(NewPage("Actually, I'm just sad that you haven't returned with our food.", 3.0f));
                    nextChapter.pages.Add(NewPage("Now, if you don't mind, I'm going to cry myself to sleep.", 3.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(1109); //Boxii exhausted response to ^
                {
                    nextChapter.pages.Add(NewPage("Don't worry. My nightly runs to the dump never fail!", 2.5f));
                }
                nextBook.chapters.Add(nextChapter);

            }
        }
        //add the book to the narrative
        allNarratives.Add(nextBook);
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
					nextChapter.pages.Add(NewPage("Maybe not.", 2.0f));
                }
                nextBook.chapters.Add(nextChapter);
            }
     //***OBJECT POP-UPS***
        //**DORMITORY**
			//*Loud Speakers
			{
				StoryChapter nextChapter = NewChapter(200); //Boxii Comment 1
				{
					nextChapter.pages.Add(NewPage("Ms. Mahble delivers daily words of encouragement through these.", 4.0f));
				}
				nextBook.chapters.Add(nextChapter);

				nextChapter = NewChapter(201); //Boxii Comment 2
                {
					nextChapter.pages.Add(NewPage("Things like, “A good cubie is an obedient cubie.”", 4.0f));
				}
				nextBook.chapters.Add(nextChapter);
			}
            //*Food
            {
                StoryChapter nextChapter = NewChapter(202); //Boxii Comment 1
                {
                    nextChapter.pages.Add(NewPage("Eating too much of this could cause blindness...", 4.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(203); //Boxii Comment 2
                {
                    nextChapter.pages.Add(NewPage("Or so I've heard.", 3.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(223); //Boxii Comment 3
                {
                    nextChapter.pages.Add(NewPage("Ugh...I hope it’s safe to carry.", 3.0f));
                }
                nextBook.chapters.Add(nextChapter);
            }
            //*Tissue Box
            {
                StoryChapter nextChapter = NewChapter(204); //Boxii Comment 1
                {
                    nextChapter.pages.Add(NewPage("The box reads, ‘At Osnosis, we pride ourselves on a 99.98% absorption rate of most nasal afflictions.’", 5.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(205); //Boxii Comment 2
                {
                    nextChapter.pages.Add(NewPage("This could be handy. I'll just borrow it for a bit.", 4.0f));
                }
                nextBook.chapters.Add(nextChapter);
            }
            //*Food Trays
            {
                StoryChapter nextChapter = NewChapter(206); //Boxii Comment 1
                {
                    nextChapter.pages.Add(NewPage("If Ms. Mahble can’t see her reflection in these, you’re going to get a timeout.", 4.0f));
                }
                nextBook.chapters.Add(nextChapter);
            }
            //*Food Chute
            {
                StoryChapter nextChapter = NewChapter(207); //Boxii Comment 1
                {
                    nextChapter.pages.Add(NewPage("This duct runs through most of the orphanage.", 3.0f));
                }
                nextBook.chapters.Add(nextChapter);
            }
            //*Food Chute Opening
            {
                StoryChapter nextChapter = NewChapter(209); //Boxii Comment 1
                {
                    nextChapter.pages.Add(NewPage("This dispenses three square meals a day.", 4.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(210); //Boxii Comment 2
                {
                    nextChapter.pages.Add(NewPage("Cold air is coming out of the opening.", 4.0f));
                }
                nextBook.chapters.Add(nextChapter);
            }
            //*Box-in-a-Box toy
            {
                StoryChapter nextChapter = NewChapter(211); //Boxii Comment 1
                {
                    nextChapter.pages.Add(NewPage("It sort of stopped working after it 'surprised' a curious cubie.", 4.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(212); //Boxii Comment 2
                {
                    nextChapter.pages.Add(NewPage("Ms. Mahble leaves it here as a reminder for what can happen to curious cubies.", 4.0f));
                }
                nextBook.chapters.Add(nextChapter);
            }
			//*Cubie Cubbies
			{
				StoryChapter nextChapter = NewChapter(221); //Boxii Comment 1
				{
					nextChapter.pages.Add(NewPage("We sleep in these.", 3.0f));
				}
				nextBook.chapters.Add(nextChapter);
			}
            //*Serving Utensil
            {
                StoryChapter nextChapter = NewChapter(222); //Boxii Comment 1
                {
                    nextChapter.pages.Add(NewPage("This week was my turn to shovel this slop onto trays for meal time.", 4.0f));
                }
                nextBook.chapters.Add(nextChapter);
            }
        //**Hallways**
            //*Orphanage Main Doors
            {
                StoryChapter nextChapter = NewChapter(213); //Boxii Comment 1
                {
                    nextChapter.pages.Add(NewPage("Locked. After twelve years you’d think I’d have learned by now.", 4.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(214); //Boxii Comment 2
                {
                    nextChapter.pages.Add(NewPage("Eh...maybe tomorrow.", 4.0f));
                }
                nextBook.chapters.Add(nextChapter);
            }
            //*The Great Eye
            {
                StoryChapter nextChapter = NewChapter(219); //Boxii Comment 1
                {
                    nextChapter.pages.Add(NewPage("The One Eye sees and knows all!", 3.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(220); //Boxii Comment 2
                {
                    nextChapter.pages.Add(NewPage("The Time Out room is back behind it, but I can’t get by if it can still see me.", 4.0f));
                }
                nextBook.chapters.Add(nextChapter);
            }
            //*Super Secret Code
            {
                StoryChapter nextChapter = NewChapter(225); //Boxii Comment 1
                {
                    nextChapter.pages.Add(NewPage("Wow...", 2.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(226); //Boxii Comment 2
                {
                    nextChapter.pages.Add(NewPage("Doesn’t get much more secure than this.", 4.0f));
                }
                nextBook.chapters.Add(nextChapter);
            }
         //**Kitchen**
            //*Food Chute Mixer
            {
                StoryChapter nextChapter = NewChapter(215); //Boxii Comment 1
                {
                    nextChapter.pages.Add(NewPage("Put your favorite seasonings into the tube to enhance our meals.", 4.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(216); //Boxii Comment 2
                {
                    nextChapter.pages.Add(NewPage("All of the spices in Globuton couldn't save this food.", 4.0f));
                }
                nextBook.chapters.Add(nextChapter);
            }
            //*Empty Pepper Shaker
            {
                StoryChapter nextChapter = NewChapter(217); //Boxii Comment 1
                {
                    nextChapter.pages.Add(NewPage("Someone REALLY likes pepper.", 3.0f));
                }
                nextBook.chapters.Add(nextChapter);
            }
            //*Pepper Flakes
            {
                StoryChapter nextChapter = NewChapter(218); //Boxii Comment 1
                {
                    nextChapter.pages.Add(NewPage(".", 3.0f));
                }
                nextBook.chapters.Add(nextChapter);
            }
            //*Keypad
            {
                StoryChapter nextChapter = NewChapter(224); //Boxii Comment 1
                {
                    nextChapter.pages.Add(NewPage("I need the super secret code to unlock the door.", 4.0f));
                }
                nextBook.chapters.Add(nextChapter);
            }
            //*Trash can
            {
                StoryChapter nextChapter = NewChapter(227); //Boxii Comment 1
                {
                    nextChapter.pages.Add(NewPage("I hope I don’t have to dig too long...", 4.0f));
                }
                nextBook.chapters.Add(nextChapter);
            }
            //*Toy Blocks
            {
                StoryChapter nextChapter = NewChapter(228); //Boxii Comment 1
                {
                    nextChapter.pages.Add(NewPage("Now who would go and throw away a perfectly good set of blocks?", 4.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(231); //Boxii Comment 2
                {
                    nextChapter.pages.Add(NewPage("It would be a crime to just leave them here.", 4.0f));
                }
                nextBook.chapters.Add(nextChapter);
            }
        //**Storage Room**
            //*Pepper Shaker
            {
                StoryChapter nextChapter = NewChapter(232); //Boxii Comment 1
                {
                    nextChapter.pages.Add(NewPage("The label reads, “Rich in vitamins, minerals, and anti-oxidants...”", 4.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(233); //Boxii Comment 2
                {
                    nextChapter.pages.Add(NewPage("”Warning! Excessive use may induce violent sneezing and other allergic reactions.”", 5.0f));
                }
                nextBook.chapters.Add(nextChapter);

                nextChapter = NewChapter(234); //Boxii Comment 3
                {
                    nextChapter.pages.Add(NewPage("The warnings continue, but I’m sure I’ll be fine.", 3.0f));
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
