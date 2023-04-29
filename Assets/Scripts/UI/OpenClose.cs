using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Button))]
public class OpenClose : MonoBehaviour
{
    public enum ButtonState
    {
        Open,
        Close
    }
    public ButtonState state;

    public GameObject panel;
    Button button;
    Vector3 panelDefaultScale;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Clicked);
        panelDefaultScale = panel.transform.localScale;
        panel.transform.localScale = Vector3.zero;
    }

    public void Clicked()
    {
        if (state == ButtonState.Open)
        {
            panel.SetActive(true);
            panel.transform.DOScale(panelDefaultScale, 0.5f).OnComplete(() =>
            {
                //Time.timeScale = 0;
            });
        }
        else
        {
            StartCoroutine(ClosePanel());
        }
    }

    IEnumerator ClosePanel()
    {
        //Time.timeScale = 1;
        panel.transform.DOScale(Vector3.zero, 0.5f);
        yield return new WaitForSeconds(1f);
        panel.SetActive(false);
    }
}
