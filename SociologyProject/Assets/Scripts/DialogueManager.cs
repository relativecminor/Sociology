using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Canvas mainMenu;

    public Animator dialogueAnimator;
    public Animator policyAnimator;
    public Canvas policyCanvas;
    public Canvas dialogueCanvas;

    public GameObject dialogueSide;
    public GameObject choiceSide;
    public GameObject dialogueBox;
    public GameObject textBox;

    private Coroutine dialogueCo;


    public Canvas schoolPolicyCanvas;
    //public Animator schoolPolicyAnimator;
    private List<int> optionIndex = new List<int>() { 8, 15, 21, 27, 34, 45, 52, 60, 66 };

    public Canvas cutScene;
    public GameObject cutSceneDialogue;
    private string[] cutSceneText = new string[2];
    private int cutSceneTextTracker = 0;

    private string[] chapter1Dialogue = new string[69];
    public int[] choiceTextNumbers = new int[9];
    private int currentTextTracker = 0;

    private int counter;


    void Start()
    {
        mainMenu.enabled = true;
        policyCanvas.enabled = false;
        dialogueCanvas.enabled = true;
        schoolPolicyCanvas.enabled = false;
        cutScene.enabled = false;
        choiceTextNumbers[0] = 5;
    
        GameManager.Instance.chapteronebackground.SetActive(false);
        GameManager.Instance.chaptertwobackground.SetActive(false);
        GameManager.Instance.chapterthreebackground.SetActive(false);
        GameManager.Instance.chapterfourbackground.SetActive(false);
        GameManager.Instance.endscreen.SetActive(false);
        GameManager.Instance.cutscene.SetActive(false);
  
    }
    private void Update()
    {
        if (GameManager.Instance.choiceA)
        {
            chapter1Dialogue[6] = "You just chose option A.";
            chapter1Dialogue[7] = "Option A path";
        } else if (GameManager.Instance.choiceB)
        {
            chapter1Dialogue[6] = "You just chose option B";
        }
    }

    public void playGame()
    {
        dialogueCanvas.enabled = true;
        mainMenu.enabled = false;
        GameManager.Instance.cutscene.SetActive(true);
        Debug.Log("cutsceen is active");
        // cut scene dialogue

        //transition to chapter 1 background
        

        chapter1Dialogue[0] = "Welcome to @itsmaya, an exploration into the variety of decisions that will affect students of color.";
        chapter1Dialogue[1] = "You will have the opportunity to allocate money at a federal level. These policies will affect students all over the country.";
        chapter1Dialogue[2] = "You will also have the ability to step into the shoes of individuals whose daily decisions have a personal affect on students of color.";
        chapter1Dialogue[3] = "Do what you feel is right, and try to make the best of the system that's in place. Good luck!";
        //Transition into first policy menu
        chapter1Dialogue[4] = "As the school year draws to a close and the weather is getting warmer, it's time for School High to select the teacher training programs for the summer.";
        chapter1Dialogue[5] = "As the Principal for Rock Creek Elementary School, people rely on you to make some tough decisions.";
        chapter1Dialogue[6] = "Excuse me, Principal Smith? The upcoming school year is approaching quickly, and we still haven't received your decisions about the faculty training this summer.";
        chapter1Dialogue[7] = "Last year we had some discipline issues with the students. We were hoping to address some of those concerns with this training.";
        chapter1Dialogue[8] = "Option A: Positive Behavior Supports \nOption B: Students in STEM Training";
        chapter1Dialogue[9] = "Thank you for letting us know! We will move forward with your selection.";
        chapter1Dialogue[10] = "...";
        chapter1Dialogue[11] = "Principal Smith, a parent reached out to us this week with a concerning issue.";
        chapter1Dialogue[12] = "Despite 17% of our students being black, only 10% of the students in our Gifted and Talented program are black.";
        chapter1Dialogue[13] = "We haven't changed any requirements, the students who score above a certain number on our placement test are accepted into the program.";
        chapter1Dialogue[14] = "We're not sure why the disconnect exists and we're not sure if we should try and do something about it.";
        chapter1Dialogue[15] = "Option A: Lower requirement for GT program. \nOption B: Change selection process for GT program.";
        chapter1Dialogue[16] = "Hmm, we will do our best to make the appropriate changes. We will move forward with care.";
        chapter1Dialogue[17] = "...";
        chapter1Dialogue[18] = "Our sister school recently made the decision to transition away from requiring uniforms.";
        chapter1Dialogue[19] = "There's talk amongst the parents and faculty about whether our school will follow.";
        chapter1Dialogue[20] = "What are your thoughts?";
        chapter1Dialogue[21] = "Option A: Do away with uniforms next year \nOption B: Continue to require student uniforms";
        chapter1Dialogue[22] = "Understood. I will write a short blurb in the newsletter addressing this.";
        chapter1Dialogue[23] = "...";
        //Transition to Chapter 2
        
        chapter1Dialogue[24] = "Welcome to Rock Creek Middle School, where you take the role of the Student Coordinator, Mr. Johnson.";
        chapter1Dialogue[25] = "Hey Mr. Johnson, do you know if there's any room for our school to request cultural competency training this year?";
        chapter1Dialogue[26] = "I've been reading up on some studies recently, and I think it could really help our school.";
        chapter1Dialogue[27] = "Option A: Request Cultural Competency Training from the state. \n Option B: Stick with the originally planned schedule.";
        // This is a split dialogue
        chapter1Dialogue[28] = "Great! I'll put in the request now.";
        chapter1Dialogue[29] = "...";
        // Beginning of long split
        chapter1Dialogue[30] = "We're going to need some decisions from you, Mr. Johnson.";
        chapter1Dialogue[31] = "We received many complaints from parents about the clothes some of the girls at this school are wearing.";
        chapter1Dialogue[32] = "It is not appropriate for a school setting, and I hope we see some stricter enforcement of the rules.";
        chapter1Dialogue[33] = "So? What are your thoughts?";
        chapter1Dialogue[34] = "Option A: Address the singling out of female dress code in an assembly. \nOption B: Create a stricter dress-code for students.";
        chapter1Dialogue[35] = "Interesting. That sounds like a good decision to me.";
        chapter1Dialogue[36] = "I'll leave the execution in your hands!";
        chapter1Dialogue[37] = "...";
        //transition to Chapter 3
        
        chapter1Dialogue[38] = "As Maya grows older and her horizon's expand, so does the reach of your power.";
        chapter1Dialogue[39] = "You find yourself in the position of superintendent of the Rock Creek School District.";
        chapter1Dialogue[40] = "Mrs. Williams, do you have a moment?";
        chapter1Dialogue[41] = "State legislature passed allowing us to station a school resource officer in all high schools.";
        chapter1Dialogue[42] = "These officers have really helped with discipline in the past.";
        chapter1Dialogue[43] = "However, there is a school requesting a counselor instead.";
        chapter1Dialogue[44] = "We wouldn't be able to hire that counselor with money from the bill. Should we give them the funding?";
        chapter1Dialogue[45] = "Option A: Allow the exception for the school. \nOption B: Stick to the plan, send an SRO.";
        chapter1Dialogue[46] = "Yes ma'am, we will follow through with your plan. Take care.";
        chapter1Dialogue[47] = "...";
        chapter1Dialogue[48] = "Mrs. Williams, I wanted to stop you and ask your advice about something.";
        chapter1Dialogue[49] = "It has come to my attention recently that there is a group of students protesting the theme of one of this years' fun dress-up days before homecoming.";
        chapter1Dialogue[50] = "The student government this year set the last day to be 'Freedom Friday' but there is a group of students saying that they don't feel included.";
        chapter1Dialogue[51] = "Do you think this should require faculty involvement, or should this be something I leave to the student government who introduced it?";
        chapter1Dialogue[52] = "Option A: Get the faculty involved. \nOption B: Leave it to the students.";
        chapter1Dialogue[53] = "I always appreciate your advice. I'll take it into account.";
        chapter1Dialogue[54] = "Have a good rest of your day.";
        chapter1Dialogue[55] = "...";
        //transition to Chapter 4
       
        chapter1Dialogue[56] = "A recent graduate of college yourself, you step into the shoes of Parker, the Student Activities Coordinator for Rock Creek University.";
        chapter1Dialogue[57] = "Hi Parker, do you have a moment? When I was in High School we had a club called Students for Black Culture.";
        chapter1Dialogue[58] = "It was a really great place for me to talk to other students of color, and I was really hoping to join something similar when I came here.";
        chapter1Dialogue[59] = "I don't feel like it's something I can start myself. Is there anything you could do?";
        chapter1Dialogue[60] = "Option A: Let's make this club! \nOption B: It looks like there's currently not room in the budget.";
        // This is a split dialogue
        chapter1Dialogue[61] = "Thanks so much! I'll be sure to join.";
        chapter1Dialogue[62] = "...";
        chapter1Dialogue[63] = "Parker, do you have a moment?";
        chapter1Dialogue[64] = "Administration says that a portion of the recent big donation is going to some of our sports teams.";
        chapter1Dialogue[65] = "Do you have any thoughts on where that money should go?";
        chapter1Dialogue[66] = "Option A: Well the football team is the biggest team... \nOption B: Maybe we should fund multiple smaller teams.";
        chapter1Dialogue[67] = "Sounds good! I'll pass your word on, and see what happens!";
        chapter1Dialogue[68] = "...";
        //transition to End
        


    }

    public void optionA()
    {
        if (currentTextTracker == 8)
        {
            GameManager.Instance.choiceA = true;
        }
        else if (currentTextTracker == 15) {
            //GameManager.Instance.choiceC = true;
        }
    }
    public void optionB()
    {
        if (currentTextTracker == 8)
        {
            GameManager.Instance.choiceB = true;
        }
    }

    public void pauseGame()
    {
        mainMenu.enabled = true;
        policyCanvas.enabled = false;
        dialogueCanvas.enabled = false;
        schoolPolicyCanvas.enabled = false;
        cutScene.enabled = false;
    }
    public void OpenBox()
    {
        dialogueAnimator.SetBool("isOpen", true);
        StartDialogue(chapter1Dialogue[currentTextTracker]);
    }

    public void openboxcutscene()
    {
        dialogueAnimator.SetBool("isOpen", true);
        StartDialogue(cutSceneText[cutSceneTextTracker]);
    }

    public void CloseBox()
    {
        dialogueAnimator.SetBool("isOpen", false);
    }

    public void NextText()
    {
        if (currentTextTracker <100)
        {
            
            if(optionIndex.Contains(currentTextTracker))
            {
                Debug.Log("contains");
                choiceSide.SetActive(true);
                dialogueSide.SetActive(false);
            }
            if (currentTextTracker == 0)
            {
                GameManager.Instance.chapteronebackground.SetActive(true);
                GameManager.Instance.cutscene.SetActive(false);
                Debug.Log("first chapter change");
            }
            if(currentTextTracker == 24 ){
                GameManager.Instance.cutscene.SetActive(true);
                GameManager.Instance.chapteronebackground.SetActive(false);
            }
            if (currentTextTracker == 25)
            {
                GameManager.Instance.cutscene.SetActive(false);
                GameManager.Instance.chaptertwobackground.SetActive(true);
            }
            if (currentTextTracker == 38)
            {
                GameManager.Instance.chaptertwobackground.SetActive(false);
                GameManager.Instance.cutscene.SetActive(true);
            }
            if (currentTextTracker == 39)
            {
                GameManager.Instance.cutscene.SetActive(false);
                GameManager.Instance.chapterthreebackground.SetActive(true);
            }
            if (currentTextTracker ==56 )
            {
                GameManager.Instance.chapterthreebackground.SetActive(false);
                GameManager.Instance.cutscene.SetActive(true);
                
            }
            if (currentTextTracker == 57)
            {
                GameManager.Instance.cutscene.SetActive(false);
                GameManager.Instance.chapterfourbackground.SetActive(true);
            }
            if (currentTextTracker == 68)
            {
                GameManager.Instance.chapterfourbackground.SetActive(false);
                GameManager.Instance.cutscene.SetActive(true);
            }
            if (currentTextTracker == 69)
            {
                GameManager.Instance.cutscene.SetActive(false);
                GameManager.Instance.endscreen.SetActive(true);
            }
            currentTextTracker++;
            OpenBox();
            Debug.Log(currentTextTracker);
        }
    }

    public void testButton2()
    {
        Debug.Log(chapter1Dialogue[6]);
    }

    public void NextTextcutscene()
    {
        if (cutSceneTextTracker != cutSceneText.Length - 1)
        {
            cutSceneTextTracker++;
            openboxcutscene();
        }
    }

    public void OpenPolicy()
    {
        //dialogueCanvas.enabled = false;
        policyCanvas.enabled = true;
        //cutScene.enabled = false;
        policyAnimator.SetBool("isOpen", true);
    }
   

    public void openCutScene()
    {
        dialogueCanvas.enabled = false;
        policyCanvas.enabled = false;
        schoolPolicyCanvas.enabled = false;
        cutScene.enabled = true;
        cutSceneText[0] = "Hey you guys";
        cutSceneText[1] = "Thought I would give you an update";
        policyAnimator.SetBool("isOpen", true);

    }


    public void ClosePolicy()
    {
        dialogueCanvas.enabled = true;
        policyCanvas.enabled = false;
        schoolPolicyCanvas.enabled = false;
        cutScene.enabled = false;
        policyAnimator.SetBool("isOpen", false);

        /**
        counter++;
        if (counter == 1)
        {
            GameManager.Instance.chap1 = true;
            Debug.Log(counter);
        }
        if (counter == 2)
        {
            GameManager.Instance.chap1done = true;
            Debug.Log(counter);
        }
        if (counter == 3)
        {
            GameManager.Instance.chap2done = true;
            Debug.Log(counter);
        }
        if (counter == 4)
        {
            GameManager.Instance.chap3done = true;
            Debug.Log(counter);
        }
        if (counter == 5)
        {
            GameManager.Instance.chap4done = true;
            Debug.Log(counter);
        }
        GameManager.Instance.nextchapter();
        **/

    }

    public void StartDialogue(string text)
    {
        if (dialogueCo != null)
        {
            StopCoroutine(dialogueCo);
        }
        dialogueCo = StartCoroutine(typeText(text));
    }

    public void HideDialogue()
    {
        StopCoroutine(dialogueCo);
    }

    IEnumerator typeText(string text)
    {
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        foreach (char c in text.ToCharArray())
        {
            textBox.GetComponent<TextMeshProUGUI>().text += c;
            yield return new WaitForSeconds(.03f);
        }

    }

  

}
