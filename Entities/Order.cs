

namespace POSSystem.Entities;

public class Order
{
    public int OrderNum { get; set; }

    public List<Pizza>? Pizza { get; set; }

    public List<Drink>? Drink { get; set; }

    public decimal Price { get; set; }

    public DateTime TimeStamp { get; set; }

}