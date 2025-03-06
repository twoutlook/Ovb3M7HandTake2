

namespace Poker2033.Hand.Canvas;
public class CanvasMobileHeroSettings
{
    private const double BaseSeatRadiusX6 = 110;  // Default width for 6-max
    private const double BaseSeatRadiusY6 = 180;  // Default height for 6-max
    private const double BaseSeatRadiusX9 = 130;  // Default width for 9-max
    private const double BaseSeatRadiusY9 = 220;  // Default height for 9-max

    public double CenterX { get;  set; } = 200;  // Table center X
    public double CenterY { get;  set; } = 260;  // Table center Y
    public double SeatOffset { get; private set; } = 20; // Adjustable offset

    public int MaxPlayers { get; private set; }  // Stores 6 or 9

    public double SeatRadiusX { get; private set; }
    public double SeatRadiusY { get; private set; }
    public double SeatCircleRadius { get; private set; } = 15; // Circle radius for seat markers

    public double CardWidth { get; private set; } = 28;
    public double CardHeight { get; private set; } = 39;
    public double CardSpacing { get; private set; } = 30;

    /// <summary>
    /// Constructor to initialize settings for 6-max or 9-max table.
    /// </summary>
    public CanvasMobileHeroSettings(int maxPlayers)
    {
        if (maxPlayers != 6 && maxPlayers != 9)
        {
            throw new ArgumentException("Only 6-max or 9-max is supported.");
        }

        MaxPlayers = maxPlayers;

        // Adjust seat placement based on table type
        if (MaxPlayers == 6)
        {
            SeatRadiusX = BaseSeatRadiusX6 + SeatOffset;
            SeatRadiusY = BaseSeatRadiusY6 + SeatOffset;
        }
        else if (MaxPlayers == 9)
        {
            SeatRadiusX = BaseSeatRadiusX9 + SeatOffset;
            SeatRadiusY = BaseSeatRadiusY9 + SeatOffset;
        }
    }

    /// <summary>
    /// Calculates the seat position for a given seat index.
    /// </summary>
    public (double X, double Y) GetSeatPosition(int seatIndex)
    {
        if (seatIndex < 0 || seatIndex >= MaxPlayers)
            throw new ArgumentException("Seat index out of range.");

        double angle = (2 * Math.PI / MaxPlayers) * seatIndex - Math.PI / 2; // Start from top-center

        double seatX = CenterX + (SeatRadiusX * Math.Cos(angle));
        double seatY = CenterY + (SeatRadiusY * Math.Sin(angle));

        return (seatX, seatY);
    }
}

//public class xxxxxCanvasMobileHeroSettings
//{
//    private const double BaseSeatRadiusX6Max = 90;  // Smaller width for 6-max
//    private const double BaseSeatRadiusY6Max = 210; // Extended height for 6-max

//    private const double BaseSeatRadiusX9Max = 100;  // Slightly wider for 9-max
//    private const double BaseSeatRadiusY9Max = 230;  // More space for 9 players

//    public double CenterX { get; set; } = 170;  // Half of 393 (Width)
//    public double CenterY { get; set; } = 260;  // Half of 844 (Height)
//    public double SeatOffset { get; set; } = 20;  // Adjusted for mobile

//    public int SeatCount { get; set; } = 6; // Default to 6-max

//    public double SeatRadiusX => (SeatCount == 6 ? BaseSeatRadiusX6Max : BaseSeatRadiusX9Max) + SeatOffset;
//    public double SeatRadiusY => (SeatCount == 6 ? BaseSeatRadiusY6Max : BaseSeatRadiusY9Max) + SeatOffset;
//    public double SeatCircleRadius { get; set; } = 15; // Scaled down for mobile

//    public double CardWidth { get; set; } = 28;    // Scaled from 36
//    public double CardHeight { get; set; } = 39;   // Scaled from 49.5
//    public double CardSpacing { get; set; } = 30;  // Scaled from 38
//}

//public class CanvasMobileHeroSettings
//{
//   // public double seatCircleRadius = 20;
//    private const double BaseSeatRadiusX = 90;  // Smaller width for vertical layout
//    private const double BaseSeatRadiusY = 210; // Extended height for vertical space

//    public double CenterX { get; set; } = 170;  // Half of 393 (Width)
//    public double CenterY { get; set; } = 260;    // Half of 844 (Height)
//    public double SeatOffset { get; set; } = 20;  // Adjusted for mobile

//    public double SeatRadiusX => BaseSeatRadiusX + SeatOffset;  // 110 (narrower width)
//    public double SeatRadiusY => BaseSeatRadiusY + SeatOffset;  // 220 (elongated height)
//    public double SeatCircleRadius { get; set; } = 15; // Scaled down from 20

//    public double CardWidth { get; set; } = 28;    // Scaled from 36
//    public double CardHeight { get; set; } = 39;   // Scaled from 49.5
//    public double CardSpacing { get; set; } = 30;  // Scaled from 38
//}

