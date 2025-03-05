

namespace Ovb3HandPwa.Client.Models;

public class CanvasMobile2Settings
{
    private const double BaseSeatRadiusX = 90;  // Smaller width for vertical layout
    private const double BaseSeatRadiusY = 200; // Extended height for vertical space

    public double CenterX { get; set; } = 170;  // Half of 393 (Width)
    public double CenterY { get; set; } = 260;    // Half of 844 (Height)
    public double SeatOffset { get; set; } = 20;  // Adjusted for mobile

    public double SeatRadiusX => BaseSeatRadiusX + SeatOffset;  // 110 (narrower width)
    public double SeatRadiusY => BaseSeatRadiusY + SeatOffset;  // 220 (elongated height)
    public double SeatCircleRadius { get; set; } = 15; // Scaled down from 20

    public double CardWidth { get; set; } = 28;    // Scaled from 36
    public double CardHeight { get; set; } = 39;   // Scaled from 49.5
    public double CardSpacing { get; set; } = 30;  // Scaled from 38
}

