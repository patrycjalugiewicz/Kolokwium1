namespace Kolokwium.DTOs;

public class CustomerPurchasesDto
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string phoneNumber { get; set; }
    public ICollection<PurchasesDto> Purchases { get; set; }
}

public class PurchasesDto
{
    public DateTime date { get; set; }
    public int? rating { get; set; }
    public double price { get; set; }
    public WashingMachineDto washingMachine{ get; set; }
    public ProgramDto program { get; set; }
}

public class WashingMachineDto
{
    public string serial { get; set; }
    public double maxWeight { get; set; }
}

public class ProgramDto
{
    public string name { get; set; }
    public int duration { get; set; }
}