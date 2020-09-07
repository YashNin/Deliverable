using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    public void SelectCharacter(Transform selectedCharacter)
    {
        GameConstants.gameConstants.selectedCharacter = selectedCharacter.name;
        SceneManager.LoadScene(1);
    }
}
