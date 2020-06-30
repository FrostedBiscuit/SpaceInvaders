using UnityEngine;

public class ParentRowProvider : MonoBehaviour, IParentProvider<EnemyRow>
{
    public EnemyRow GetParent()
    {
        return transform.parent.GetComponent<EnemyRow>();
    }
}
