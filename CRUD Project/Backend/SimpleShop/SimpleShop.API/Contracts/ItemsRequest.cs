namespace SimpleShop.API.Contracts
{
    public record ItemsRequest(
        string Title,
        string Description,
        float Price);
}
