using UnityEngine;

public class AnimToEntity : MonoBehaviour
{
    public Entity entity;
    private void Start()
    {
        entity = GetComponentInParent<Entity>();
    }
    public void TriggerAttack()
    {
        entity.TriggerAttack();
    }
    public void FinishAttack()
    {
        entity.FinishAttack();
    }
    public void TriggerCharge()
    {
        entity.TriggerCharge();
    }
    public void FinishCharge()
    {
        entity.FinishCharge();
    }
    public void TriggerAlert()
    {
        entity.TriggerAlert();
    }
    public void FinishAlert()
    {
        entity.FinishAlert();
    }

    public void SlashesActiveOne()
    {
        entity.SlashesActiveOne();
    }
}
