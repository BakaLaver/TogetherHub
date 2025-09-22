using Domain.Abstractions;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Topic:Entity<TopicId>
    {
        public string Title { get; set; } = default!;
        public DateTime? EventStrat { get; set; } = default!;
        public string Summery { get; set; } = default!;
        public string TopycType { get; set; } = default!;
        public Location Location { get; set; } = default!;

        public static Topic Create(
            TopicId id, string title, DateTime eventStart,
            string summery, string topicType, Location location)

        {
            ArgumentException.ThrowIfNullOrWhiteSpace(title);
            ArgumentException.ThrowIfNullOrWhiteSpace(summery);
            ArgumentException.ThrowIfNullOrWhiteSpace(topicType);

            Topic topic = new Topic
            {
                Id = id,
                Title = title,
                EventStrat = eventStart,
                Summery = summery,
                Location = location
            };

            return topic;
        }
    }
}
