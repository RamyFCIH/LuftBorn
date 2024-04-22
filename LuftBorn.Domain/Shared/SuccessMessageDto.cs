using System;

namespace LuftBorn.Domain.Shared
{
    public sealed class SuccessMessageDto
    {
        public Guid Id { get; init; }
        public string Message { get; init; }
        public bool IsSuccess { get; init; }
    }
}
