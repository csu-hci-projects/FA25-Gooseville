using UnityEngine;

public class PaperUI : MonoBehaviour
{
    [SerializeField] private GameObject paperCanvas;

    public void OpenPaper()
    {
        paperCanvas.SetActive(true);
    }

    public void ClosePaper()
    {
        paperCanvas.SetActive(false);
    }

    public GameObject getPaperCanvas()
    {
        return paperCanvas;
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
