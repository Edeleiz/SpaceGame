public class TreasureData
{
    public string LocationName;
    public int X;
    public int Y;
    public string Message;

    public static TreasureData FromServerTreasureData(ServerTreasureData data)
    {
        var d = new TreasureData();
        d.LocationName = data.locationName;
        d.X = data.x;
        d.Y = data.y;
        d.Message = data.message;
        return d;
    }
}