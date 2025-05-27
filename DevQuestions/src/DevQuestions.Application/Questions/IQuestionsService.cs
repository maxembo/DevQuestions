using DevQuestions.Contracts.Questions;
using DevQuestions.Domain.Questions;

namespace DevQuestions.Application.Questions;

public interface IQuestionsService
{
    Task<Guid> Create(CreateQuestionDto createQuestionDto, CancellationToken cancellationToken);

    Task<Guid> Update(Guid questionId, UpdateQuestionDto updateQuestionDto, CancellationToken cancellationToken);

    Task<Guid> Delete(Guid questionId, CancellationToken cancellationToken);

    Task<Question> GetBy(Guid questionId, CancellationToken cancellationToken);
}