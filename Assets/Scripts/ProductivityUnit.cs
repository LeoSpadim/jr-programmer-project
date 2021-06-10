using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    private ResourcePile m_CurrentPile = null;
    public float ProductivityMultiplyer = 2;

    protected override void BuildingInRange()
    {
        if (m_CurrentPile == null)
        {
            //The notation “as ResourcePile” sets the pile variable to m_Target only if m_Target is a ResourcePile type
            ResourcePile pile = m_Target as ResourcePile;
            if (pile != null)
            {
                m_CurrentPile = pile;
                m_CurrentPile.ProductionSpeed *= ProductivityMultiplyer;
            }
        }
    }

    private void ResetProductivity()
    {
        if (m_CurrentPile != null)
        {
            m_CurrentPile.ProductionSpeed /= ProductivityMultiplyer;
            m_CurrentPile = null;
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivity();
        base.GoTo(target);
    }

    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
    }
}
