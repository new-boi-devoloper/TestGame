using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    public GameObject objectToHide;
    public float interactionDistance = 2f; // Расстояние для взаимодействия
    private bool isHidden = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float distance = Vector3.Distance(transform.position, objectToHide.transform.position);
            if (distance <= interactionDistance)
            {
                if (isHidden)
                {
                    objectToHide.SetActive(true);
                    isHidden = false;
                }
                else
                {
                    objectToHide.SetActive(false);
                    isHidden = true;
                }
            }
        }
    }
}