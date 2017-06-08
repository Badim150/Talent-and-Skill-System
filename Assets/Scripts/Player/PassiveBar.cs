using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassiveBar : MonoBehaviour {

    private List<SkillButton> m_buttons;
    [SerializeField] private SkillButtonPool m_buttonObjectPool;

    private void Awake()
    {
        m_buttons = new List<SkillButton>();
    }

    public void NewPassive(Skill skill)
    {
        GameObject newButton = m_buttonObjectPool.GetObject();
      //  newButton.transform.localScale();
        newButton.transform.SetParent(this.transform);

        SkillButton skillButton = newButton.GetComponent<SkillButton>();
        skillButton.Setup(skill, null, null);
        m_buttons.Add(skillButton);
    }
}
