using UnityEngine;
using UnityEngine.UI;

public class tattiDes : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Button button;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button.onClick.AddListener(OnTer);
        

    }

    public void OnTer()
    {
        
        panel.SetActive(true);
        Debug.Log("‰Ÿ‚µ‚½");
    }

    // Update is called once per frame
}
