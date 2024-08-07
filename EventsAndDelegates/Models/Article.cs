using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsAndDelegates.Models
{
    public record Article : DomainEntity
    {
        private Article(string title, string description, Guid authorId)
        {
            Title = title;
            Description = description;
            AuthorId = authorId;
        }

        public static Article Create(string title, string description, Guid authorId)
        {
            var article = new Article(title, description, authorId);
            return article;
        }

        public string Title { get; init; }
        public string Description { get; init; }
        public Guid AuthorId { get; init; }
        public bool IsDeleted { get; init; } = false;
        public bool IsPublished { get; init; } = false;

        public Article Create()
        {
            return this with { IsPublished = true };
        }

        public Article Update(string title, string description)
        {
            return this with { Title = title, Description = description };
        }

        public Article Draft()
        {
            return this with { IsPublished = false };
        }
        public Article Delete()
        {
            return this with { IsDeleted = true };
        }
    }
}