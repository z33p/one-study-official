using System;

namespace OneStudy.Core.Models.Interfaces
{
    public interface IOneModel
    {
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}