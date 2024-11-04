using System;

public static class GameManager
{
    public static Action onPlayerDied;
    public static Action onPlayerWin;
    public static Action onTimeOver;
    public static Action onPause;
    public static Action onContinueGame;

    public static Inventory CurrentInventory { get; set; }
}
 

