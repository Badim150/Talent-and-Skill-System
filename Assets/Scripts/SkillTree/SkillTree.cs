using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;


public class SkillTree : MonoBehaviour {

    public int m_currentTier = 1;
    public List<Skill> m_learnableSkills;
    public List<Skill> m_learnedSkills;
    private List<SkillButton> m_buttons;
    public SkillButtonPool m_buttonObjectPool;
    private List<UIVertex> m_vertexList;

    [SerializeField] private GameObject tier1;
    [SerializeField] private GameObject tier2;
    [SerializeField] private GameObject tier3;
    [SerializeField] private GameObject tier4;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject m_lineRenderer;

    private void Awake()
    {
        m_buttons = new List<SkillButton>();
        m_learnedSkills = new List<Skill>();
        Init();
        UpdateTree();    
    }

    private void Start()
    {
        StartCoroutine(DrawLines());
    }

    IEnumerator DrawLines()
    {
        yield return new WaitForSeconds(1);
        DrawConections();
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


    private void DrawConections()
    {
        for (int i = 0; i < m_buttons.Count; i++)
        {
            Skill skill1 = m_buttons[i].m_skill;
            for (int j = 0; j < skill1.m_childOf.Count; j++)
            {
                for (int k = 0; k < m_buttons.Count; k++)
                {
                    if(skill1.m_childOf[j].m_name == m_buttons[k].m_skill.m_name)
                    {
                        GameObject line = Instantiate(m_lineRenderer, canvas.transform);
                        line.transform.SetAsFirstSibling();
                        line.GetComponent<UILineTextureRenderer>().Points[0] = m_buttons[i].WhereAmIInTheCanvas();
                        line.GetComponent<UILineTextureRenderer>().Points[1] = m_buttons[k].WhereAmIInTheCanvas();
                    }
                }
            }
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


