using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour {

    public int m_currentTier = 1;
    public List<Skill> m_learnableSkills;
    public List<Skill> m_learnedSkills;
    private List<SkillButton> m_buttons;
    public SkillButtonPool m_buttonObjectPool;

    [SerializeField] private GameObject tier1;
    [SerializeField] private GameObject tier2;
    [SerializeField] private GameObject tier3;
    [SerializeField] private GameObject tier4;


    private void Start()
    {
        m_buttons = new List<SkillButton>();
        m_learnedSkills = new List<Skill>();
        Init();
        UpdateTree();
    }

    private void Init()
    {
        for (int i = 0; i < m_learnableSkills.Count; i++)
        {
            Skill skill = m_learnableSkills[i];
            skill.m_skillTree = this;
            GameObject newButton = m_buttonObjectPool.GetObject();

            switch (skill.m_tier)
            {
                case 1:
                    newButton.transform.SetParent(tier1.transform);
                    break;
                case 2:
                    newButton.transform.SetParent(tier2.transform);
                    break;
                case 3:
                    newButton.transform.SetParent(tier3.transform);
                    break;
                case 4:
                    newButton.transform.SetParent(tier4.transform);
                    break;
                default:
                    break;
            }

            SkillButton skillButton = newButton.GetComponent<SkillButton>();
            skillButton.Setup(skill, this);
            m_buttons.Add(skillButton);
        }
    }
    
    public void UpdateTree()
    {
        for (int i = 0; i < m_buttons.Count; i++)
        {        
            m_buttons[i].m_button.interactable = m_buttons[i].IsActive();            
        }
    }

    public void LearnSkill(Skill skill)
    {
        m_learnedSkills.Add(skill);
    }

    public bool KnowsSkill(Skill skill)
    {
        for (int i = 0; i < m_learnedSkills.Count; i++)
        {
            if (m_learnedSkills[i] == skill) return true;           
        }
        return false;
    }
}
