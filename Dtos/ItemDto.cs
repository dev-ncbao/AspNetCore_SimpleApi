using System;

namespace Catalog.Dtos
{
    public class ItemDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public int Price { get; init; }
        public DateTimeOffset DateCreated { get; init; }
    }
}