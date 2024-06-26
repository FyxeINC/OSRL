public class UI_VerticalGroup : UI_GroupBase
{
#region Constructors
	public UI_VerticalGroup(string name, Point screenPosition, int width, int height) 
		: base(name, screenPosition, width, height)
	{
	}
#endregion
	
	public AnchorPointVertical ListAnchorPoint = AnchorPointVertical.top;


	protected override void UpdateChildPositions()
	{
        base.UpdateChildPositions();

		if (ListAnchorPoint == AnchorPointVertical.top)
		{
			int startingHeight = 0;
			for (int i = 0; i < GetChildrenCollectionCount(); i++)
			{
				UIObject childObject = (GetChildrenCollection()[i] as UIObject);
				childObject.SetAnchorPoint(AnchorPointHorizonal.stretch, AnchorPointVertical.top);
                int newHeight = childObject.Height;
                if (UseGroupObjectHeight)
                {
                    newHeight = GroupObjectHeight;
                }
				childObject.SetSize(0, newHeight);
				childObject.SetLocalPosition(0, startingHeight);
				startingHeight += newHeight + Spacing;
			}
		}
		else if (ListAnchorPoint == AnchorPointVertical.bottom)
		{
			int startingHeight = 0;
			for (int i = GetChildrenCollectionCount()-1; i >= 0; i--)
			{
				UIObject childObject = (GetChildrenCollection()[i] as UIObject);
				childObject.SetAnchorPoint(AnchorPointHorizonal.stretch, AnchorPointVertical.bottom);
				int newHeight = childObject.Height;
                if (UseGroupObjectHeight)
                {
                    newHeight = GroupObjectHeight;
                }
				childObject.SetSize(0, newHeight);
				childObject.SetLocalPosition(0, startingHeight);
				startingHeight -= newHeight + Spacing;
			}
		}
	}
}