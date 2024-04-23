using LuftBorn.Domain.Abstractions;
using System;

namespace LuftBorn.Domain.Books
{
    public sealed class Book : Entity
    {
        private Book(Guid id, string name,string description,DateTime publishedDate)
            : base(id)
        {
            Name = name;
            Description = description;
            PublishedDate = publishedDate;
        }
        public string Name { get; private set; }

        public string Description { get; private set; }


        public DateTime PublishedDate { get; private set; }

        /// <summary>
        /// Our Static Factory Method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description""></param>
        /// <param name="publishedDate""></param>
        /// <returns></returns>
        public static Book Create(Guid id, string name,string description,DateTime publishedDate)
        {
            var newModel = new Book(id,name,description,publishedDate);
            return newModel;
        }

    }
}
