namespace ClothingStore.Server.Infrastructure.Services
{
    using System.Collections.Generic;

    public class Result
    {
        public bool Succeeded { get; private set; }

        public bool Failure => !this.Succeeded;

        public List<Error> Error { get; set; }

        public static implicit operator Result(bool succeeded) 
            => new Result { Succeeded = succeeded };

        public static implicit operator Result(string error)
            => new Result
            {
                Succeeded = false,
                Error = new List<Error>()
                {
                    new Error
                    {
                        Description = error
                    }
                }
            };
    }
}
