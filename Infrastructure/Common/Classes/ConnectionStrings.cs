﻿namespace Infrastructure.Common.Classes
{
    public class ConnectionStrings
    {
        public const string SectionName = "ConnectionStrings";

        public bool UseSecondary { get; init; }
        public string DefaultConnection { get; init; } = null!;
        public string SecondaryConnection { get; init; } = null!;
    }
}
