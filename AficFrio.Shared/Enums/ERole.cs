using System.ComponentModel;

namespace AficFrio.Shared.Enums
{
    public enum ERole
    {
        [Description("User")]
        User = 1,

        [Description("Admin")]
        Admin = 2,

        [Description("Dev")]
        Dev = 3
    }
}
