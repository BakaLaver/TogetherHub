

using Domain.ValueObjects;

namespace Domain.Model
{
    public class Topic:Entity<TopicId>
    {
        public string Title { get; set; } = default!;
        public DateTime? EventStrat { get; set; } = default!;
        public string Summary { get; set; } = default!;
        public string TopicType { get; set; } = default!;
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
                Summary = summery,
                Location = location,
                TopicType = topicType
            };

            return topic;
        }
       
    }
}
