namespace Ovb3HandPwa.Client.Models;

public class CanvasSettings
{
    private const double BaseSeatRadiusX = 250;
    private const double BaseSeatRadiusY = 162;

    public double CenterX { get; set; } = 400;
    public double CenterY { get; set; } = 230;
    public double SeatOffset { get; set; } = 30;

    public double SeatRadiusX => BaseSeatRadiusX + SeatOffset;
    public double SeatRadiusY => BaseSeatRadiusY + SeatOffset;
    public double SeatCircleRadius { get; set; } = 20;
    public double CardWidth = 36;
    public double CardHeight = 49.5;
    public double CardSpacing = 38;
}
