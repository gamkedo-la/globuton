using UnityEngine;
using System.Collections;
using DialogueHelpers;
using UnityEngine.UI;

public delegate void DialogueInteractionHandler();

public class PopDialogue : MonoBehaviour {

    public event DialogueInteractionHandler Dialogue_Enter;
    public event DialogueInteractionHandler Dialogue_Exit;

    protected StoryChapter displayPages;
    
    public DialogueInteract interactData;

    [Tooltip("Determines how long the dialogue will remain on screen after appearing. 0 for infinite.")]
    public float displayTime = 0; //leave at zero if you want the dialogue to have no timer

    [Tooltip("This will determine if the dialogue will appear upon instantiation. If false it will appear based on some other condition, see Interact Data.")]
    public bool autoStart = false;
    
    [Tooltip("If true, this dialogue will sync it's text with the related text in the NarrativeStorage script for the chosen DialogueID.")]
    public bool linkNarrative = true; //should this dialogue sync with the stored narrative?

    [Tooltip("DialogueID should be an existing dialogue that has been built in the NarrativeStorage script.")]
    public int dialogueID = -1;

    [Tooltip("Reference to the text component this dialogue should control. This text gets updated by linkNarrative.")]
    public Text bodyText;
    //private Text headerText;   //will there be headers in the dialogue, such as the name of who is talking? or who the dialogue belongs to?

    protected bool hasStarted = false;

    public void PullNarrativePages(NarrativeStorage roomNarrative)
    {
        displayPages = new StoryChapter();
        //Is this dialogue linked to the narrative?
        if (linkNarrative && roomNarrative != null)
        {
            //Debug.Log("narrative not null");
            if (dialogueID != -1)
            {
                //Debug.Log("Find dialogue id: " + dialogueID.ToString());
                //dialogueID is set, find the narrative chapter with the same dialogueID from 
                StoryChapter findChapter = roomNarrative.FindChapter(dialogueID);
                if(findChapter != null)
                {
                    //Debug.Log("Found Chapter");
                    displayPages = findChapter.GetClone();
                }
            }
        }
    }

    void StartReading()
    {
        //Debug.Log("StartReading");
        if (displayPages != null)
        {
            //Debug.Log("SetCurrentPage");
            displayPages.currentPage = 0;
            //Debug.Log("pages: " + displayPages.pages.Count.ToString());
            StoryPage nextPage = displayPages.GetCurrentPage();
            if (nextPage != null)
            {
                //Debug.Log("Update with page");
                UpdateBodyText(nextPage.text);
                StartCoroutine(ReadPage(nextPage.readTime));
            }
        }
    }

    public virtual void SyncByInspector()
    {
        StoryPage nextPage = displayPages.GetCurrentPage();
        if (nextPage != null)
        {
            //Debug.Log("Update with page");
            UpdateBodyText(nextPage.text);
        }
    }

    IEnumerator ReadPage(float readTime)
    {
        yield return new WaitForSeconds(readTime);
        StoryPage nextPage = displayPages.AdvancePages();
        if (nextPage != null)
        {
            UpdateBodyText(nextPage.text);
            StartCoroutine(ReadPage(nextPage.readTime));
        }
    }

    public void UpdateBodyText(string pageText)
    {
        //if dialogueID is set for this component then populate the bodyText with the resulting pages from the narrative
        if(bodyText)
        {
            //Debug.Log("updating page text");
            bodyText.text = pageText;
        }
    }

    // Use this for initialization
    protected virtual void Start () {

        if (displayPages == null)
            displayPages = new StoryChapter();
        if (linkNarrative && dialogueID != -1)
        {
            //Debug.Log("LinkNarrative now.");
            displayPages = new StoryChapter();
            GameObject narrativeObject = GameObject.FindGameObjectWithTag("Narrative");
            NarrativeStorage sceneStorage = narrativeObject.GetComponent<NarrativeStorage>();
            //load the text from the story manager
            PullNarrativePages(sceneStorage);
        }
        
        transform.GetChild(0).gameObject.SetActive(false);
    }

    

    protected virtual void Awake()
    {
        if (!autoStart && interactData != null && interactData.watchDialogue != null)
        {
            //there is a dialogue here, based on the watchInteract do something
            switch (interactData.watchInteract)
            {
                case InteractType.ENTER:
                    interactData.watchDialogue.Dialogue_Enter += Begin;
                    break;
                case InteractType.EXIT:
                    interactData.watchDialogue.Dialogue_Exit += Begin;
                    break;
                case InteractType.DELAYED_ENTER:
                    interactData.watchDialogue.Dialogue_Enter += DelayedBegin;
                    break;
                case InteractType.DELAYED_EXIT:
                    interactData.watchDialogue.Dialogue_Exit += DelayedBegin;
                    break;
                default:
                    Debug.Log("Invalid InteractType chosen for watchInteract variable.");
                    break;
            }
        }
    }

    // Update is called once per frame
    protected virtual void Update () {
        if (autoStart && !hasStarted)
            Begin();
    }

    public virtual void Begin()
    {
        hasStarted = true;
        StartReading();
        //start the displayTimer
        transform.GetChild(0).gameObject.SetActive(true);
        //show the text
        if(displayTime != 0)
        {
            if (displayPages != null && displayPages.GetChapterReadTime() > displayTime)
                Debug.Log("Warning: Chapter read time exceeds dialogue display time. Some narrative may get cutoff.");
            StartCoroutine(DisplayTimer());
        }
        OnDialogue_Enter();
    }

    IEnumerator DisplayTimer()
    {
        yield return new WaitForSeconds(displayTime);
        if(displayPages != null && displayPages.GetCurrentPage() != null)
            StopCoroutine(ReadPage(displayPages.GetCurrentPage().readTime));
        OnDialogue_Exit();
    }

    void DelayedBegin()
    {
        StartCoroutine(WaitToBegin());
    }
    
    IEnumerator WaitToBegin()
    {
        //Debug.Log("Waiting to begin");
        yield return new WaitForSeconds(interactData.delayedInteract);
        Begin();
    }

    protected virtual void OnDialogue_Enter()
    {
        //This dialogue is closing,
        if (Dialogue_Enter != null)
        {
            Dialogue_Enter();
        }
    }

    protected virtual void OnDialogue_Exit()
    {
        //This dialogue is closing,
        if (Dialogue_Exit != null)
        {
            Dialogue_Exit();
        }
        Destroy(gameObject);
    }
}
