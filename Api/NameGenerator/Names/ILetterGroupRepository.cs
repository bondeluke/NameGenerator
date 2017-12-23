using System;
using System.Collections.Generic;
namespace RandomNameGenerator
{
    interface ILetterGroupRepository
    {
        IEnumerable<LetterGroup> LetterGroupPool { get; }
    }
}
