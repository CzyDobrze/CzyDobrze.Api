﻿using System.Collections;
using System.Collections.Generic;
using CzyDobrze.Core;

namespace CzyDobrze.Domain.Entities.Content
{
    public class Section : Entity
    {
        public string Title { get; }
        public string Description { get; }
        
        public IEnumerable<Exercise> Exercises { get; }
    }
}