using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playButtonClickListener : MonoBehaviour {

    public Button PlayButton;

    void Start ()
    {
        Button btn = PlayButton.GetComponent<Button>();
        btn.onClick.AddListener(LoadSceneOnClick);
    }

    void LoadSceneOnClick()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
