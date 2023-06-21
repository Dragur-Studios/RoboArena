using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private RectTransform interactionPopupCanvas;
    [SerializeField] private GameObject interactionPopupPrefab;
    private GameObject currentInteractionPopup;
    public bool isInteracting = false;

    // Update is called once per frame
    void Update()
    {
        Camera cam = GetComponentInChildren<Camera>();

        Vector2 midScreen = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        Ray ray = cam.ScreenPointToRay(midScreen);

        Debug.DrawLine(ray.origin, ray.origin + (ray.direction * 3.0f), Color.red);

        if (Physics.Raycast(ray, out RaycastHit hit, 3.0f, interactableLayer))
        {
            Vector2 viewportPos = cam.WorldToViewportPoint(hit.point);
            Vector2 anchoredPos = new Vector2(viewportPos.x * Screen.width, viewportPos.y * Screen.height);
            interactionPopupCanvas.anchoredPosition = anchoredPos;

            if (currentInteractionPopup == null && !isInteracting)
            {
                currentInteractionPopup = Instantiate(interactionPopupPrefab, interactionPopupCanvas);
              
            }
        }
        else
        {
            DestroyPopup();
        }



        if (currentInteractionPopup != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Matchmaker.Connect();
                isInteracting = true;
            }
        }
    }

    private void DestroyPopup()
    {
        if (currentInteractionPopup != null)
        {
            Destroy(currentInteractionPopup);
            currentInteractionPopup = null;
        }
    }
}
