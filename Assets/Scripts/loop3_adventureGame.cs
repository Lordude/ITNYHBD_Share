using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class loop3_adventureGame : MonoBehaviour
{
    public string message_state1, message_state2, message_state3, message_state4, message_state4_hasKey, message_state5, message_state6, message_state7, message_state8, message_state9, message_state10, message_state11, message_state12, end_state;
    public GameObject inputFieldObj, firstCam, secondCam, sfx_question, sfx_agree, sfx_incorrect, keyToLoop, preload_loop_trigbox, corridor_light, sfx_shriek_parent;
    public Animator mirPlayerAnim;
    public InputField inputField;
    public bool hasKey;
    [SerializeField] TextMeshProUGUI current_message;
    public int current_state;

    private string answer = "open the door";


    // Start is called before the first frame update
    void Start()
    {
        current_message.text = message_state1;
        current_state = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            checkAnswer1();
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            checkAnswer2();
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            checkAnswer3();
        }
        if(inputField)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                string playerAnswer = inputField.text.ToLower();
                // playerAnswer = playerAnswer.ToLower();
                if(playerAnswer == answer)
                {
                    inputFieldObj.SetActive(false);
                    current_message.text = message_state6;
                    sfx_agree.SetActive(true);
                    hasKey = true;
                    sfx_shriek_parent.SetActive(true);
                    current_state = 6;
                }
                else
                {
                    sfx_incorrect.SetActive(false);
                    inputFieldObj.SetActive(false);
                    current_message.text = message_state12;
                    current_state = 12;
                    sfx_incorrect.SetActive(true);
                }
            }
        }
    }

    void checkAnswer1()
    {
        if(current_state == 1)
        {
            current_message.text = message_state2;
            mirPlayerAnim.SetTrigger("state1to2");
            current_state = 2;
            return;
        }
        if(current_state == 2)
        {
            current_message.text = message_state3;
            mirPlayerAnim.SetTrigger("state2to3");
            current_state = 3;
            return;
        }
        if(current_state == 3)
        {
            if(!hasKey){current_message.text = message_state4;}
            if(hasKey){current_message.text = message_state4_hasKey;}
            mirPlayerAnim.SetTrigger("state3to4");
            current_state = 4;
            return;   
        }
        if(current_state == 4)
        {
            if(!hasKey){inputTextHandler();}
            if(hasKey){current_message.text = message_state3;current_state = 3;mirPlayerAnim.SetTrigger("state4to3");}
            return;   
        }
        if(current_state == 6)
        {
            current_message.text = message_state4_hasKey;
            current_state = 4;
            return;
        }
        if(current_state == 7)
        {
            current_message.text = message_state1;
            current_state = 1;
            return;
        }
        if(current_state == 12)
        {
            current_message.text = message_state4;
            current_state = 4;
            return;
        }
        if(current_state == 10)
        {
            current_message.text = message_state11;
            current_state = 11;
            mirPlayerAnim.SetTrigger("state10to11");
            return;
        }
        if(current_state == 11)
        {
            current_message.text = message_state10;
            current_state = 10;
            mirPlayerAnim.SetTrigger("state11to10");
            return;
        }
        if(current_state == 8)
        {
            current_message.text = message_state9;
            current_state = 9;
            return;
        }
        if(current_state == 9)
        {
            current_message.text = message_state8;
            current_state = 8;
            return;
        }
    }

    void checkAnswer2()
    {
        if(current_state == 1)
        {
            current_message.text = message_state10;
            current_state = 10;
            mirPlayerAnim.SetTrigger("state1to10");
            return;
        }
        if(current_state == 2)
        {
            current_message.text = message_state1;
            current_state = 1;
            mirPlayerAnim.SetTrigger("state2to1");
            return;
        }
        if(current_state == 3)
        {
            current_message.text = message_state2;
            current_state = 2;
            mirPlayerAnim.SetTrigger("state3to2");
            return;   
        }
        if(current_state == 4)
        {
            if(!hasKey){current_message.text = message_state3;current_state = 3;}
            mirPlayerAnim.SetTrigger("state4to3");
            return;
        }
        if(current_state == 8)
        {
            current_message.text = message_state2;
            current_state = 2;
            mirPlayerAnim.SetTrigger("state3to2");
            return;
        }
        if(current_state == 10)
        {
            current_message.text = message_state1;
            current_state = 1;
            mirPlayerAnim.SetTrigger("state10to1");
            return;
        }
    }

    void checkAnswer3()
    {
        if(current_state == 1)
        {
            if(!hasKey)
            {
                current_message.text = message_state7;
                current_state = 7;
            }
            if(hasKey)
            {
                current_message.text = end_state;
                current_state = 13;
                keyToLoop.SetActive(false);
                preload_loop_trigbox.SetActive(true);
                corridor_light.SetActive(false);
                StartCoroutine(waitAndEnd());
            }
            return;
        }
        if(current_state == 2)
        {
            current_message.text = message_state8;
            current_state = 8;
            mirPlayerAnim.SetTrigger("state2to3");
            return;
        }
    }

    void inputTextHandler()
    {
        current_message.text = message_state5;
        current_state = 5;
        sfx_question.SetActive(true);
        inputFieldObj.SetActive(true);
        inputField.ActivateInputField();
    }

    IEnumerator waitAndEnd()
    {
        yield return new WaitForSeconds(4.0f);
        firstCam.SetActive(false);
        secondCam.SetActive(true);
    }
}
