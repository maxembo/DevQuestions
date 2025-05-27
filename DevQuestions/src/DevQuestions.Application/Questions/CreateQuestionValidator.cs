using DevQuestions.Contracts.Questions;
using FluentValidation;

namespace DevQuestions.Application.Questions;

public class CreateQuestionValidator : AbstractValidator<CreateQuestionDto>
{
    public CreateQuestionValidator()
    {
        RuleFor(question => question.Title)
            .NotEmpty()
            .MaximumLength(500)
            .WithMessage("Заголовок не может быть пустыми или больше 500");

        RuleFor(question => question.Text)
            .NotEmpty()
            .MaximumLength(5000)
            .WithMessage("Текст не может быть пустым или больше 5000");

        RuleFor(question => question.UserId)
            .NotEmpty();
    }
}