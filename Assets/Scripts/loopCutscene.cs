using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopCutscene : MonoBehaviour
{

    public GameObject cutsceneCam, player, lightToClose, entranceToDestroy, fakeWall;
    public float cutsceneTime;
    public Animator doorAnim;
    public AudioSource sfxOpenDoor, sfxCloseDoor;
    public int currentLevel;

    void Start()
    {
        PlayerPrefs.SetInt("level", currentLevel);
        StartCoroutine(cutscene());
    }
    IEnumerator cutscene()
    {
        doorAnim.ResetTrigger("close");
        doorAnim.SetTrigger("open");
        sfxOpenDoor.Play();
        yield return new WaitForSeconds(cutsceneTime);
        lightToClose.SetActive(false);
        doorAnim.ResetTrigger("open");
        doorAnim.SetTrigger("close");
        sfxCloseDoor.Play();
        fakeWall.SetActive(true);
        entranceToDestroy.SetActive(false);
        player.SetActive(true);
        cutsceneCam.SetActive(false);
    }
}
