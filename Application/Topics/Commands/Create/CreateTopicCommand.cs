namespace Application.Topics.Commands.Create
{
    public record CreateTopicCommand(CreateTopicDto TopicDto) :ICommand<CreateTopicResult>;

    public record CreateTopicResult(TopicResponseDto Result);
}
