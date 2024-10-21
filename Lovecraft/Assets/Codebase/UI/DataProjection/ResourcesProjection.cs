namespace Lovecraft.Client.Ui.DataProjection
{
  public class ResourcesProjection : IResourcesProjection
  {
    public int WoodAmount { get; private set; }
    public int StoneAmount { get; private set; }
    public int IronAmount { get; private set; }
    public int WarpstoneAmount { get; private set; }

    public void ProjectResources(int woodAmount, int stoneAmount, int ironAmount, int warpstoneAmount)
    {
      WoodAmount = woodAmount;
      StoneAmount = stoneAmount;
      IronAmount = ironAmount;
      WarpstoneAmount = warpstoneAmount;
    }
  }
}


