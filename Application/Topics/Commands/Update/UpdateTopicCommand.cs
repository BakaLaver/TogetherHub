
namespace Application.Topics.Commands.Update
{
    public record UpdateTopicCommand(Guid id, UpdateTopicDto UpdateTopicDto) : ICommand<UpdateTopicResult>;

    public record UpdateTopicResult(TopicResponseDto Result);

}
