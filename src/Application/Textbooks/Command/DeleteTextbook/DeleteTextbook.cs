﻿using System;
using MediatR;

namespace CzyDobrze.Application.Textbooks.Command.DeleteTextbook
{
    public class DeleteTextbook : IRequest
    {
        public DeleteTextbook(Guid id)
        {
            Id = id;
        }
        
        public Guid Id { get; set; }
    }
}