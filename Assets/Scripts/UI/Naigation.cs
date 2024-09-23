using UnityEngine;

public class Naigation : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject game;
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject basket;

    public void NavigateToGame()
    {
        menu.SetActive(false);
        game.SetActive(true);
        spawner.SetActive(true);
        basket.SetActive(true);  
    }

    public void NavigateToMenu() 
    {
        game.SetActive(false);
        menu.SetActive(true);
        spawner.SetActive(false);
        basket.SetActive(false);

    }
}
