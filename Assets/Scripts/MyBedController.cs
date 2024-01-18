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
            GiveConsent();
            PickedNotes();
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

    public void GiveConsent()
    {
        // Call if consent has been given by the user
        AnalyticsService.Instance.StartDataCollection();
        Debug.Log($"Consent has been provided. The SDK is now collecting data!");
    }
}
