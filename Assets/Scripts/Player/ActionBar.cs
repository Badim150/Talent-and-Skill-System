using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour {

    private List<ActionButton> m_buttons;


    private void Awake()
    {       
        m_buttons = GetComponentsInChildren<ActionButton>().ToList<ActionButton>();       
    }

    public ActionButton getNextAvailableButton()
    {
        for (int i = 0; i < m_buttons.Count; i++)
        {
            if (!m_buttons[i].m_isActive) return m_buttons[i];
        }
        return null;
    }
}
