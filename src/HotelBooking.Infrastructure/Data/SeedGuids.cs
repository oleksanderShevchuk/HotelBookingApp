namespace HotelBooking.Infrastructure.Data;

public static class SeedGuids
{
    public static readonly Guid AdminRoleId = Guid.NewGuid();
    public static readonly Guid ClientRoleId = Guid.NewGuid();

    public static readonly Guid StandardRoomCategoryId = Guid.NewGuid();
    public static readonly Guid DeluxeRoomCategoryId = Guid.NewGuid();
    public static readonly Guid SuiteRoomCategoryId = Guid.NewGuid();
}
