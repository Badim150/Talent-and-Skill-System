using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour {

    public string m_name;
    public Sprite m_sprite;
    public bool m_isActiveAbility;

    public abstract void Learn();

    public virtual void Use()
    {
        if (!m_isActiveAbility) return;          
    }
        

}
