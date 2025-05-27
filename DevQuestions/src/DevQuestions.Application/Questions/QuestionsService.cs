using DevQuestions.Contracts.Questions;
using DevQuestions.Domain.Questions;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DevQuestions.Application.Questions;

// TODO Сделать интерфейс QuestionsService и доделать CRUD фичи
public class QuestionsService : IQuestionsService
{
    private readonly IQuestionsRepository _questionsRepository;
    private readonly IValidator<CreateQuestionDto> _validator;
    private readonly ILogger<QuestionsService> _logger;

    public QuestionsService(
        IQuestionsRepository questionsRepository,
        IValidator<CreateQuestionDto> validator,
        ILogger<QuestionsService> logger)
    {
        _questionsRepository = questionsRepository;
        _logger = logger;
        _validator = validator;
    }

    public async Task<Question> GetBy(Guid questionId, CancellationToken cancellationToken)
    {
        return await _questionsRepository.GetByAsync(questionId, cancellationToken);
    }

    public async Task<Guid> Create(CreateQuestionDto questionDto, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(questionDto, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        int openUserQuestionsCount = await _questionsRepository
            .GetOpenUserQuestionsAsync(questionDto.UserId, cancellationToken);

        if (openUserQuestionsCount > 3)
            throw new Exception("Пользователь не может создать больше 3 нерешенных вопросов");

        var questionId = Guid.NewGuid();

        var question = new Question(
            questionId,
            questionDto.UserId,
            questionDto.Title,
            questionDto.Text,
            null,
            questionDto.TagIds);

        await _questionsRepository.AddAsync(question, cancellationToken);

        _logger.LogInformation("Created question with id {questionId}", questionId);

        return questionId;
    }

    public async Task<Guid> Update(Guid questionId, UpdateQuestionDto questionDto, CancellationToken cancellationToken)
    {
        return Guid.Empty;
    }

    public async Task<Guid> Delete(Guid questionId, CancellationToken cancellationToken)
    {
        return await _questionsRepository.DeleteAsync(questionId, cancellationToken);
    }
}