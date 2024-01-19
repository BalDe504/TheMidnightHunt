using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.Services.Analytics;
using Unity.Services.Core;
using Unity.Services.Core.Analytics;
using UnityEngine.SceneManagement;

public class enemyAI : MonoBehaviour
{
    [SerializeField] private KeyInventory _keyInventory = null;

    public NavMeshAgent ai;
    public List<Transform> destinations;
    public Animator aiAnim;
    public float walkSpeed, chaseSpeed, minIdleTime, maxIdleTime, idleTime, sightDistance, catchDistance, chaseTime, minChaseTime, maxChaseTime, jumpscareTime;
    public bool walking, chasing;
    public Transform player;
    Transform currentDest;
    Vector3 dest;
    int randNum, randNum2;
    public int destinationAmount;
    public Vector3 rayCastOffset;
    public string deathScene;

    


    void Start()
    {
            walking = true;
            randNum = Random.Range(0, destinationAmount - 1);
            currentDest = destinations[randNum];
    }
    
    void Update()
    {
        if (_keyInventory.enemyTriggered == true)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            RaycastHit hit;

            if (Physics.Raycast(transform.position + rayCastOffset, direction, out hit, sightDistance))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    walking = false;

                    StopCoroutine("stayIdle");
                    StopCoroutine("chaseRoutine");
                    StartCoroutine("chaseRoutine");

                    aiAnim.ResetTrigger("walk");
                    aiAnim.ResetTrigger("idle");
                    aiAnim.SetTrigger("sprint");

                    chasing = true;
                }
            }

            if (chasing == true)
            {
                dest = player.position;

                ai.destination = dest;
                ai.speed = chaseSpeed;

                if (ai.remainingDistance <= catchDistance)
                {
                    player.gameObject.SetActive(false);

                    aiAnim.ResetTrigger("sprint");
                    aiAnim.SetTrigger("jumpscare");

                    StartCoroutine(deathRoutine());

                    chasing = false;
                }
            }

            if (walking == true)
            {
                dest = currentDest.position;
                ai.destination = dest;
                ai.speed = walkSpeed;

                if (ai.remainingDistance <= ai.stoppingDistance)
                {
                    randNum2 = Random.Range(0, 2);
                    if (randNum2 == 0)
                    {
                        randNum = Random.Range(0, destinationAmount);
                        currentDest = destinations[randNum];
                    }

                    if (randNum2 == 1)
                    {
                        aiAnim.ResetTrigger("walk");
                        aiAnim.SetTrigger("idle");

                        ai.speed = 0;

                        StopCoroutine("stayIdle");
                        StartCoroutine("stayIdle");

                        walking = false;
                    }
                }
            }
        }
        
    }

    IEnumerator stayIdle()
    {
        idleTime = Random.Range(minIdleTime, maxIdleTime);
        
        yield return new WaitForSeconds(idleTime);
        
        walking = true;
        
        randNum = Random.Range(0, destinationAmount);
        
        currentDest = destinations[randNum];
        
        aiAnim.ResetTrigger("idle");
        aiAnim.SetTrigger("walk");
    }

    IEnumerator chaseRoutine()
    {
        chaseTime = Random.Range(minChaseTime, maxChaseTime);

        yield return new WaitForSeconds(chaseTime);

        walking = true;
        chasing = false;
        
        randNum = Random.Range(0, destinationAmount);
        
        currentDest = destinations[randNum];
        
        aiAnim.ResetTrigger("sprint");
        aiAnim.SetTrigger("walk");
    }

    IEnumerator deathRoutine()
    {
        try
        {
            PickedNotes();
            KeysTimer();
            LevelCompletedCustomEvent();
        }
        catch (ConsentCheckException e)
        {
            Debug.Log(e.ToString());
        }

        yield return new WaitForSeconds(jumpscareTime);
        SceneManager.LoadScene(deathScene);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void KeysTimer()
    {


        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            {"keysTime", "Player found first key in: " + _keyInventory.firstKeyTime + " and second key in: " + _keyInventory.secondKeyTime}
        };

        AnalyticsService.Instance.CustomData("keysTimer", parameters);
        Debug.Log(_keyInventory.firstKeyTime);
        Debug.Log(_keyInventory.secondKeyTime);
    }

    private void PickedNotes()
    {


        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            {"notesNumber", "Player picked " + _keyInventory.NotesPicked + " notes in scene " + SceneManager.GetActiveScene().name}
        };

        AnalyticsService.Instance.CustomData("pickedNotes", parameters);
    }

    private void LevelCompletedCustomEvent()
    {
        string currentLevel = SceneManager.GetActiveScene().name;

        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            { "levelName", "Level: " + currentLevel}
        };

        AnalyticsService.Instance.CustomData("levelCompleted", parameters);

        AnalyticsService.Instance.Flush();
    }

}
