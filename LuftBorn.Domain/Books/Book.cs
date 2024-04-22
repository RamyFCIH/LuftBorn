using LuftBorn.Domain.Abstractions;
using System;

namespace LuftBorn.Domain.Books
{
    public sealed class Book : Entity
    {
        private Book(Guid id, string name)
            : base(id)
        {
            Name = name;
        }
        public string Name { get; private set; }



        /// <summary>
        /// Our Static Factory Method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Book Create(Guid id, string name)
        {
            var newModel = new Book(id,name);
            return newModel;
        }

    }
}
