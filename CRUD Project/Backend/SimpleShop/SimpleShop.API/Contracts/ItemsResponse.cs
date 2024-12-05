namespace SimpleShop.API.Contracts
{
    public record ItemsResponse(
        Guid Id,
        string Title,
        string Description,
        float Price);
}
