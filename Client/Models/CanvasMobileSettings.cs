

namespace Ovb3HandPwa.Client.Models;

public class CanvasMobileSettings
{
    // Adjusted for phone screen size (393x844)
    private const double BaseSeatRadiusX = 140;  // Scaled from 250 for smaller screen
    private const double BaseSeatRadiusY = 90;   // Scaled from 162 for smaller screen

    public double CenterX { get; set; } = 196.5;  // Half of 393
    public double CenterY { get; set; } = 422;    // Half of 844
    public double SeatOffset { get; set; } = 20;  // Adjusted for mobile

    public double SeatRadiusX => BaseSeatRadiusX + SeatOffset;  // 160
    public double SeatRadiusY => BaseSeatRadiusY + SeatOffset;  // 110
    public double SeatCircleRadius { get; set; } = 15; // Scaled down from 20

    public double CardWidth { get; set; } = 28;    // Scaled from 36
    public double CardHeight { get; set; } = 39;   // Scaled from 49.5
    public double CardSpacing { get; set; } = 30;  // Scaled from 38
}

