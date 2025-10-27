using UnityEngine;

public class LetterUI : MonoBehaviour
{
    [SerializeField] private GameObject letterPanel;

    public void OpenLetter()
    {
        letterPanel.SetActive(true);
    }

    public void CloseLetter()
    {
        letterPanel.SetActive(false);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
