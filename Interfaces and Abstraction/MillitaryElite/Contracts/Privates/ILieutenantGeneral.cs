namespace MillitaryElite.Contracts.Privates
{
    using MillitaryElite.Models;
    using System.Collections.Generic;

    public interface ILieutenantGeneral
    {
        HashSet<Private> Privates { get; } 
    }
}
