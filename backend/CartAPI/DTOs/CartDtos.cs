namespace CartAPI.DTOs
{
    public record CartRequestDto(string CustomerId, ICollection<CartItemRequestDto> Items);

    public record CartItemRequestDto(int ProductId, int Quantity);

    public record CartResponseDto(string CustomerId, decimal TotalPrice, ICollection<CartItemResponseDto> Items);

    public record CartItemResponseDto(
        int ProductId, string Name, string Size, decimal Price, string Image, int Quantity);
}
