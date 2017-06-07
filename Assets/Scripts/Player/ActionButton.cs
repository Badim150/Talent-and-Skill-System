using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour {

    [SerializeField] private Text m_nameField;
    [SerializeField] private Text m_descriptionField;
    [SerializeField] private Image m_iconImage;

    private Skill m_skill;
    public bool isActive = false;

    public void Setup(Skill skill)
    {
        m_skill = skill;
        m_nameField.text = skill.m_name;
        m_iconImage.sprite = skill.m_icon;
    }

    public void HandleClick()
    {
        m_skill.OnUse();
    }
}
