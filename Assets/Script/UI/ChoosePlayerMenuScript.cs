/*using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;

public class UIMenuScript : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private AudioSource audio;

    private void Start()
    {
        InputSystem.onAnyButtonPress.CallOnce(control => Debug.Log(control));
        audio = GetComponent<AudioSource>();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(0, 0, 0, 255);

        GameObject.Find("MainCanvas/" + panelSelected(gameObject.name)).GetComponent<Image>().color =
            new Color32(255, 255, 255, 255);
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(290, 258);
    }


    public void OnSelect(BaseEventData eventData)
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(192, 44, 44, 255);


        GameObject.Find("MainCanvas/" + panelSelected(gameObject.name)).GetComponent<Image>().color =
            new Color32(192, 44, 44, 255);

        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(268, 238);
        audio.Play();
    }

    private string panelSelected(string name)
    {
        var returnedPanel = "";
        switch (gameObject.name)
        {
            case "P1":
                returnedPanel = "BT_P1";
                break;
            case "P2":
                returnedPanel = "BT_P2";

                break;

        return returnedPanel;
    }
}*/