using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ECardState
{
    drawpile,
    tableau,
    target,
    discard
}

public class CardProspector : Card
{
    public ECardState state = ECardState.drawpile;
    public List<CardProspector> hiddenBy = new List<CardProspector>();
    public int layoutID;
    public SlotDef slotDef;

    override public void OnMouseUpAsButton()
    {
        Prospector.S.CardClicked(this);
        base.OnMouseUpAsButton();
    }
}
