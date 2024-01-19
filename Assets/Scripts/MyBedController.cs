using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;
using Unity.Services.Core;
using Unity.Services.Core.Analytics;
using UnityEngine.SceneManagement;

public class MyBedController : MonoBehaviour
{
    [SerializeField] private KeyInventory _keyInventory = null;


    public void SwitchScenes()
    {
        try
        {
            PickedNotes();
            LevelCompletedCustomEvent();
        }
        catch (ConsentCheckException e)
        {
            Debug.Log(e.ToString());
        }

        SceneManager.LoadScene("Hospital");
    }


    private void PickedNotes()
    {


        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            {"notesNumber", "Player picked " + _keyInventory.NotesPicked + " notes in scene " + SceneManager.GetActiveScene().name}
        };

        AnalyticsService.Instance.CustomData("pickedNotes", parameters);

        AnalyticsService.Instance.Flush();

        Debug.Log(_keyInventory.NotesPicked);
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
