using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.InputSystem; // Adicione esta biblioteca

public class InputNavigator : MonoBehaviour
{
    private EventSystem system;

    void Start()
    {
        system = EventSystem.current;
    }

    void Update()
    {
        // Verifica se o teclado existe e se a tecla Tab foi pressionada neste frame
        if (Keyboard.current != null && Keyboard.current.tabKey.wasPressedThisFrame)
        {
            if (system == null || system.currentSelectedGameObject == null) return;

            Selectable current = system.currentSelectedGameObject.GetComponent<Selectable>();
            if (current == null) return;

            // Verifica se o Shift está segurado
            bool isShiftPressed = Keyboard.current.shiftKey.isPressed;

            Selectable next = isShiftPressed ?
                (current.FindSelectableOnUp() ?? current.FindSelectableOnLeft()) :
                (current.FindSelectableOnDown() ?? current.FindSelectableOnRight());

            if (next != null)
            {
                TMP_InputField inputField = next.GetComponent<TMP_InputField>();
                if (inputField != null)
                {
                    inputField.ActivateInputField();
                }

                system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
            }
        }
    }
}