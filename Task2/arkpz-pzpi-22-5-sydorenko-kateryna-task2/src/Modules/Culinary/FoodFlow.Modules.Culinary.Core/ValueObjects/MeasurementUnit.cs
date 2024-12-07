namespace FoodFlow.Modules.Culinary.Core.ValueObjects;

public class MeasurementUnit
{
    public string Unit { get; set; }

    protected MeasurementUnit() { }
    public MeasurementUnit(string unit)
    {
        Unit = unit;
    }

    public static MeasurementUnit Grams = new MeasurementUnit("g");
    public static MeasurementUnit Milliliters = new MeasurementUnit("ml");
    public static MeasurementUnit Pieces = new MeasurementUnit("pcs");
    public static MeasurementUnit Kilograms = new MeasurementUnit("kg");

    public static MeasurementUnit Create(string unit) => new MeasurementUnit(unit);
}
