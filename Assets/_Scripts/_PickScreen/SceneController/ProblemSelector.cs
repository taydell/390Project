using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ProblemSelector : MonoBehaviour {

    private GameObject _queens;
    private GameObject _towers;
    private GameObject _description;
    private Text _descriptionText;
    private GameObject activeUIHolder;
	
    void Awake()
    {
        activeUIHolder = GameObject.Find("Active Scene Scripts Holder");
        _queens = GameObject.Find("8Queens");
        _towers = GameObject.Find("Towers of Hanoi");
        _description = GameObject.Find("Description");

        _descriptionText = _description.GetComponent<Text>();
        _descriptionText.text = "Hover over your options for a better look!";
    }

    public void OnClick(Button button)
    {
        var UI = activeUIHolder.transform.Find(GlobalVariables.UIName);
        UI.gameObject.SetActive(true);

        if (button.name.Equals("queens_scene_button"))
        {
            SceneManager.LoadScene("8Queens");
            UI.Find(GlobalVariables.queenDropDownName).gameObject.SetActive(true);
        }
        else if (button.name.Equals("towers_scene_button"))
        {
            SceneManager.LoadScene("TowersOfHanoi");
            UI.Find(GlobalVariables.towerDropDownName).gameObject.SetActive(true);
        }
        else if (button.name.Equals("return_to_selection"))
        {
            SceneManager.LoadScene("ProblemSelection");
            UI.gameObject.SetActive(false);
            UI.Find(GlobalVariables.towerDropDownName).gameObject.SetActive(false);
            UI.Find(GlobalVariables.queenDropDownName).gameObject.SetActive(false);
        }
    }

    public void ButtonHover(Button button)
    {
        if (button.name.Equals("queens_scene_button"))
        {
            _descriptionText.text = "Eight Queens Problem";
            _queens.transform.SetAsLastSibling();
        }
        else if (button.name.Equals("towers_scene_button"))
        {
            _descriptionText.text = "Towers Of Hanoi Problem";
            _towers.transform.SetAsLastSibling();
        }
    }
}
