using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TorchHandler : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject torch;
    public Light light;
    public float power = 1;
    public bool isOn;
    public UnityEvent DrainEvent;
    public Image BatteryBar;

    private void Awake()
    {
        torch.SetActive(false);       
    }

    public void PickUp()
    {
      torch.SetActive(true);
      isOn = true;  
    }

    // Update is called once per frame
    private void Update()
    {
        if (isOn && power > 0)

        {
            power -= 0.02f * Time.deltaTime;
            light.intensity = Mathf.Clamp01(power);
            BatteryBar.fillAmount = Mathf.Clamp01(power);
            

        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn;
            light.enabled = isOn;
        }
        if (power <=0)
        {
            // gameManager.TriggerLoseState();
            DrainEvent.Invoke();
        }
        
    }
}

