﻿using CzyDobrze.Domain.Content.Comment;
using FluentValidation;

namespace CzyDobrze.Application.Comments.ToExercises.Commands
{
    public class CreateExerciseValidator : AbstractValidator<CreateExerciseComment>
    {
        public CreateExerciseValidator()
        {
            RuleFor(x => x.ExerciseId)
                .NotEmpty();

            RuleFor(x => x.Content)
                .NotEmpty();
        }
    }
}