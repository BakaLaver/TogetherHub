using Shared.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Topics.Queries.GetTopics
{
    public record GetTopicsQuery : IQuery<GetTopicsResult>;

    public record GetTopicsResult (List<TopicResponseDto> Topics);


}
