using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : Skill {
    public override void LearnSkill()
    {
        base.LearnSkill();
        //give player fireball skill
    }

    public override void OnUse()
    {
        base.OnUse();
        //shoot fireball
    }
}
