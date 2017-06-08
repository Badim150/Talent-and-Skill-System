using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour {
 
    [SerializeField] private Text m_nameField;
    [SerializeField] private Text m_descriptionField;
    [SerializeField] public Image m_iconImage;
    [SerializeField] private Image m_purchasedImage;
    

    public Skill m_skill;
    private SkillTree m_skillTree;
    private PlayerController m_playerController;

    public Button m_button;
       
    public void Setup(Skill skill, SkillTree skillTree, PlayerController playerController)
    {
        m_skill = skill;
        m_skillTree = skillTree;
        m_playerController = playerController;
        m_nameField.text = skill.m_name;
        m_iconImage.sprite = skill.m_icon;
        m_purchasedImage.enabled = false;        
    }
	
	public void Learn()
    {      
        if (m_skill.CanBeLearned())
        {
            m_skill.LearnSkill(); 
            m_skillTree.UpdateTree();
            m_purchasedImage.enabled = true;
            m_playerController.NewSkill(m_skill);
        }        
    }

    public bool IsActive()
    {
        if (m_skillTree.KnowsSkill(m_skill)) return false;

        for (int i = 0; i < m_skill.m_childOf.Count; i++)
        {
            if (!m_skillTree.KnowsSkill(m_skill.m_childOf[i])) return false;
        }
        return true;
    }

    public void HandleClick()
    {
        Learn();      
    }

    public Vector3 WhereAmIInTheCanvas()
    {
        RectTransform transform = this.gameObject.GetComponent<RectTransform>();
        return transform.position;
    }
}
