namespace test
{
    using System;
    using System.Text;

    public class Human
    {
        private const int FirstNameMinLength = 4;
        private const int LastNameMinLength = 3;

        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get => this.firstName;
            private set
            {
                if (char.IsLower(value[0]))
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: {nameof(this.firstName)}");
                }
                if (value.Length < FirstNameMinLength)
                {
                    throw new ArgumentException($"Expected length at least {FirstNameMinLength} symbols! Argument: {nameof(this.firstName)}");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            private set
            {
                if (char.IsLower(value[0]))
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: {nameof(lastName)}");
                }
                if (value.Length < LastNameMinLength)
                {
                    throw new ArgumentException($"Expected length at least {LastNameMinLength} symbols! Argument: {nameof(lastName)}");
                }
                this.lastName = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"First Name: {this.FirstName}");
            sb.AppendLine($"Last Name: {this.LastName}");
            return sb.ToString().TrimEnd();
        }

    }
}
