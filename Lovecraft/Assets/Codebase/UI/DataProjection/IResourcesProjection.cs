namespace Lovecraft.Client.Ui.DataProjection
{
  public interface IResourcesProjection
  {
    public int WoodAmount { get; }
    public int StoneAmount { get; }
    public int IronAmount { get; }
    public int WarpstoneAmount { get; }

    public void ProjectResources(int woodAmount, int stoneAmount, int ironAmount, int warpstoneAmount);
  }
}

