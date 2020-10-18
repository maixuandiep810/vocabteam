using System;

namespace vocabteam.Helpers
{
    public class RepositoryException001 : Exception
    {
        public RepositoryException001()
        {
        }

        public RepositoryException001(string message)
            : base(message)
        {
        }

        public RepositoryException001(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}