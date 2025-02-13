namespace Project.BL.DTOs.BasketDTO;

public class BasketDto
{
    public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
    public double TotalPrice
    {
        get
        {
            return Items.Sum(item => (item.Price * item.Quantity) );
        }
    }

}
