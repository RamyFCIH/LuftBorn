﻿using System;

namespace LuftBorn.Application.Dtos.Books
{
    public sealed class BookDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public DateTime PublishedDate { get; init; }
    }
}
