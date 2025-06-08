namespace Kolokwium.DTOs;

public class AddWashingMashineDto
{
    public WashingMaschineDto washingMashine { get; set; }
    public ICollection<AvaliableProgramsDto> avaliablePrograms { get; set; }
}

public class WashingMaschineDto
{
    public double maxWeight { get; set; }
    public string serialNumber  { get; set; }
}

public class AvaliableProgramsDto
{
    public string programName { get; set; }
    public double price { get; set; }
}